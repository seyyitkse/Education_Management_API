using Education.BusinessLayer.Abstract;
using Education.DtoLayer.Dtos.ApplicationUserDto;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudentAsync([FromBody] CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    var user = await _userManager.FindByEmailAsync(model.Mail);
                    await _userManager.AddToRoleAsync(user, "Ogrenci");

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Bazı değerler girilmedi!");
        }

        [HttpPost("RegisterTeacher")]
        public async Task<IActionResult> RegisterTeacherAsync([FromBody] CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    var user = await _userManager.FindByEmailAsync(model.Mail);
                    await _userManager.AddToRoleAsync(user, "Ogretmen");

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Bazı değerler girilmedi!");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _applicationUserService.LoginUserAsync(model);
                if (user.IsSuccess)
                {
                    var token = CreateToken(model,isRefreshToken:false);
                    return Ok(new { Token = token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Ok("Logged out successfully.");
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(refreshTokenDto.Token);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(username);
            if (user == null || user.RefreshToken != refreshTokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid token or refresh token expired.");
            }

            var newToken = CreateToken(new LoginUserDto { Email = username }, isRefreshToken: true);

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); // Or any other desired refresh token expiration time

            await _userManager.UpdateAsync(user);

            return Ok(new { Token = newToken, RefreshToken = user.RefreshToken });
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AuthSettings:Token"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            var jwtSecurityToken = principal.Identity as ClaimsIdentity;
            if (jwtSecurityToken == null || !jwtSecurityToken.IsAuthenticated || jwtSecurityToken.FindFirst(ClaimTypes.Email) == null)
            {
                throw new SecurityTokenException("Invalid token.");
            }

            return principal;
        }

        private  string  CreateToken(LoginUserDto user, bool isRefreshToken)
        {
            ApplicationUser userRole = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
            var roleNames = _userManager.GetRolesAsync(userRole).Result;

            string joinRoleName = string.Join(',', roleNames);

            // öğrenci, dekan, 

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));

            var expiryTime = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: new List<Claim>
                {
                    new Claim("Email", user.Email ),
                    new Claim("Role", joinRoleName )
                },
                expires: expiryTime,
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}
