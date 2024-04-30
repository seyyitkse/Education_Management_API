using Education.DtoLayer.Dtos.ApplicationUserDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Abstract
{
    public interface IApplicationUserService:IGenericService<ApplicationUser>
    {
        Task<UserResponse> RegisterUserAsync(CreateUserDto model);
        Task<UserResponse> LoginUserAsync(LoginUserDto model);
    }
}
