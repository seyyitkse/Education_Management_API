using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.DtoLayer.Dtos.ApplicationUserDto;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Education.BusinessLayer.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private readonly IApplicationUserDal _applicationUserDal;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;


        public ApplicationUserManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IApplicationUserDal applicationUserDal)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUserDal = applicationUserDal;
        }

        public async Task<UserResponse> LoginUserAsync(LoginUserDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserResponse
                {
                    Message = "Bu mail ile kayıtlı öğrenci bulunamadı",
                    IsSuccess = false
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Message = "Giriş başarılı",
                    IsSuccess = true
                };
            }
            else
            {
                return new UserResponse
                {
                    Message = "Hatalı parola",
                    IsSuccess = false
                };
            }
        }

        public async Task<UserResponse> RegisterUserAsync(CreateUserDto model)
        {
            if (model == null)
                throw new NullReferenceException("Boş veriler var");

            if (model.Password != model.ConfirmPassword)
            {
                return new UserResponse
                {
                    Message = "Girdiğiniz parolalar eşleşmiyor.",
                    IsSuccess = false,
                };
            }

            var identityuser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Mail,
                UserName = model.Mail,
                CafeteriaCardID=model.CafeteriaCardID,
                DepartmentID = model.DepartmentID
            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);
            if (result.Succeeded)
            {
 
                await _userManager.AddToRoleAsync(identityuser, "Ogrenci");

                return new UserResponse
                {
                    Message = "Öğrenci oluşturma işlemi başarıyla gerçekleştirildi.",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            return new UserResponse
            {
                Message = "Öğrenci oluşturulamadı!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public void TDelete(ApplicationUser entity)
        {
            _applicationUserDal.Delete(entity);
        }

        public ApplicationUser TGetById(int id)
        {
            return _applicationUserDal.GetById(id);
        }

        public List<ApplicationUser> TGetList()
        {
            return _applicationUserDal.GetList();
        }

        public void TInsert(ApplicationUser entity)
        {
            _applicationUserDal.Insert(entity);
        }

        public void TUpdate(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
        }
    }
}
