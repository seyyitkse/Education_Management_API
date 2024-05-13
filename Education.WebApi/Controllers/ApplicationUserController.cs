using Education.DataAccessLayer.Concrete;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _dbContext;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public  IActionResult GetApplicationUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpGet("getStudents")]
        public async Task<IActionResult> GetStudentUsersByDepartment()
        {
            var studentUsers = await _userManager.GetUsersInRoleAsync("Ogrenci");

            return Ok(studentUsers);
        }
        [HttpGet("getTeachers")]
        public async Task<IActionResult> GetTeacherUsersByDepartment()
        {
            var teacherUsers = await _userManager.GetUsersInRoleAsync("Ogretmen");

            return Ok(teacherUsers);
        }
        [HttpGet("getStudents/departmentName")]
        public async Task<IActionResult> GetStudentUsersByDepartment(string departmentName)
        {
            // Departman adına göre departmanı buluyoruz
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                return NotFound("Belirtilen departman bulunamadı");
            }

            // Öğrenci kullanıcılarını alırken, sadece belirli bir departman ID'sine sahip olanları seçiyoruz
            var studentUsers = await _userManager.GetUsersInRoleAsync("Ogrenci");

            return Ok(studentUsers);
        }

        [HttpGet("getTeachers/departmentName")]
        public async Task<IActionResult> GetTeacherUsersByDepartment(string departmentName)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                return NotFound("Belirtilen departman bulunamadı");
            }

            var teacherUsers = await _userManager.GetUsersInRoleAsync("Ogretmen");

            return Ok(teacherUsers);
        }

    }
}
