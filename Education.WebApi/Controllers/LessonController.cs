using Education.BusinessLayer.Abstract;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService=lessonService;
        }

        [HttpGet]
        public IActionResult LessonList()
        {
            var values = _lessonService.TGetList();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddLesson(Lesson Lesson)
        {
            _lessonService.TInsert(Lesson);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateLesson(Lesson Lesson)
        {
            _lessonService.TUpdate(Lesson);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetLesson(int id)
        {
            var values = _lessonService.TGetById(id);
            return Ok(values);
        }
    }
}
