﻿using Education.BusinessLayer.Abstract;
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

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult DepartmentList()
        {
            var values = _departmentService.TGetList();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddDepartment(Department Department)
        {
            _departmentService.TInsert(Department);
            return Ok();
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
