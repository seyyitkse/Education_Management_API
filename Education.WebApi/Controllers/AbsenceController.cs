using Education.BusinessLayer.Abstract;
using Education.DtoLayer.Dtos.AbsenceDto;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        readonly IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }
        [HttpGet]
        public IActionResult AbsenceList()
        {
            var values = _absenceService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAbsence(CreateAbsenceDto absenceDto)
        {
            _absenceService.TInsert(absenceDto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAbsence(int id)
        {
            var values = _absenceService.TGetById(id);
            _absenceService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbsence(Absence absence)
        {
            _absenceService.TUpdate(absence);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAnnouncement(int id)
        {
            var values = _absenceService.TGetById(id);
            return Ok(values);
        }
    }
}
