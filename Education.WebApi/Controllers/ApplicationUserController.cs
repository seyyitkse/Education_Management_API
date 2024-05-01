using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("studentList")]
        public  IActionResult GetApplicationUsers()
        {
           var students = _userManager.GetUsersInRoleAsync("Ogrenci").Result.ToList();
           return Ok(students);
        }
        [HttpGet("teacherList")]
        public  IActionResult GetApplicationTeachers()
        {
           var teachers = _userManager.GetUsersInRoleAsync("Ogretmen").Result.ToList();
           return Ok(teachers);
        }
        [HttpGet("secretaryList")]
        public  IActionResult GetApplicationAdmins()
        {
           var admins = _userManager.GetUsersInRoleAsync("Sekreter").Result.ToList();
           return Ok(admins);
        }
        [HttpGet("deanList")]
        public  IActionResult GetRoles()
        {
           var deans = _userManager.GetUsersInRoleAsync("Dekan").Result.ToList();
           return Ok(deans);
        }
    }
}
