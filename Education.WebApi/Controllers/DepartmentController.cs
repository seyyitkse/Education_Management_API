using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //dtoya gore ayarlama yapılacak!!!
        IDepartmentService _departmentService;
        IDepartmentDal _departmentDal;

        public DepartmentController(IDepartmentService departmentService, IDepartmentDal departmentDal)
        {
            _departmentService = departmentService;
            _departmentDal = departmentDal;
        }

        [HttpGet]
        public IActionResult DepartmentList()
        {
            var values = _departmentService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddDepartment(string departmentName, string description)
        {
            var existingDepartment = _departmentDal.GetDepartmentByName(departmentName);

            if (existingDepartment != null)
            {
                return BadRequest($"'{departmentName}' isimli bölüm zaten mevcut.");
            }

            Department department = new Department();
            department.DepartmentName = departmentName;
            department.Description = description;

            var departmentCode = _departmentService.GenerateDepartmentCode(departmentName);
            department.DepartmentCode = departmentCode;

            _departmentService.TInsert(department);
            return Ok($"'{departmentName}' isimli '{departmentCode}' kodlu bölüm oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var values = _departmentService.TGetById(id);
            _departmentService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department Department)
        {
            _departmentService.TUpdate(Department);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var values = _departmentService.TGetById(id);
            return Ok(values);
        }
    }
}
