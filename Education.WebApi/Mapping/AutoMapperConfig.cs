using AutoMapper;
using Education.DtoLayer.Dtos.AnnouncementDto;
using Education.DtoLayer.Dtos.ApplicationRoleDto;
using Education.DtoLayer.Dtos.ApplicationUserDto;
using Education.DtoLayer.Dtos.DepartmentDto;
using Education.EntityLayer.Concrete;

namespace Education.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
            CreateMap<ApplicationRole, CreateRoleDto>().ReverseMap();

            CreateMap<Announcement, CreateAnnouncementDto>().ReverseMap();
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            //CreateMap<ApplicationRole, CreateRoleDto>().ReverseMap();
            //CreateMap<ApplicationRole, CreateRoleDto>().ReverseMap();
        }
    }
}
