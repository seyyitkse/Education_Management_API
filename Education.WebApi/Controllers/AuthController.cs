using Education.BusinessLayer.Abstract;
using Education.DtoLayer.Dtos.ApplicationUserDto;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Education.WebApi.Controllers
{
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
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
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
                    var token = CreateToken(model);
                    return Ok(new { Token = token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }

        private string CreateToken(LoginUserDto user)
        {
            ApplicationUser userRole = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
            var roleNames = _userManager.GetRolesAsync(userRole).Result;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
            };

            foreach (var item in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), 
                notBefore: DateTime.Now, 
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            //string tokenResponse = tokenAsString;
            //return new UserResponse
            //{
            //    Message = tokenResponse,
            //    IsSuccess = true,
            //    ExpireDate = token.ValidTo,
            //};
            //private string CreateToken(LoginUserDto user) şeklinde yazıyoruz.
            return tokenAsString;
        }
    }
}
