﻿using Education.BusinessLayer.Abstract;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
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
        [HttpPut]
        public IActionResult UpdateGrade(Grade Grade)
        {
            _gradeService.TUpdate(Grade);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGrade(int gradeId)
        {
            var values = _gradeService.TGetById(gradeId);
            return Ok(values);
        }
        [HttpGet("studentGrades")]
        public IActionResult GetMyGrades(int studentId)
        {
            var grades = _gradeService.GetGradesByStudentId(studentId);
            return Ok(grades);
        }
    }
}
