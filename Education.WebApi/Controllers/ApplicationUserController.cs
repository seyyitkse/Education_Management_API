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

        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public  IActionResult GetApplicationUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpGet("Students/{departmentId}")]
        public async Task<IActionResult> GetStudentUsersByDepartment(int departmentId)
        {
            var studentUsers = await _userManager.GetUsersInRoleAsync("Ogrenci");
            var studentUsersInDepartment = studentUsers.Where(u => u.DepartmentID == departmentId).ToList();

            return Ok(studentUsersInDepartment);
        }
        [HttpGet("Teachers/{departmentId}")]
        public async Task<IActionResult> GetTeacherUsersByDepartment(int departmentId)
        {
            var teacherUsers = await _userManager.GetUsersInRoleAsync("Ogretmen");
            var teacherUsersInDepartment = teacherUsers.Where(u => u.DepartmentID == departmentId).ToList();

            return Ok(teacherUsersInDepartment);
        }
    }
}
