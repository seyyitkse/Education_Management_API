using Education.BusinessLayer.Abstract;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public IActionResult GradeList()
        {
            var values = _gradeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGrade(Grade Grade)
        {
            _gradeService.TInsert(Grade);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGrade(int id)
        {
            var values = _gradeService.TGetById(id);
            _gradeService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGrade(Grade Grade)
        {
            _gradeService.TUpdate(Grade);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGrade(int id)
        {
            var values = _gradeService.TGetById(id);
            return Ok(values);
        }
    }
}
