using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Student.Repository.Models;
using Student.Repository.Models.DTO;
using System;
namespace Student.API.Controllers.Student
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        StudentModel _studentModel;
        public StudentController(StudentModel studentModel)
        {
            _studentModel = studentModel;
        }
        [HttpPost]
        public IActionResult Save([FromBody] StudentDTO student)
        {
            _studentModel.Set(student);
            var StudentDTO = _studentModel.Save();
            return Ok(StudentDTO);
        }
        public IActionResult List([FromBody] StudentDTO student)
        {
            _studentModel.Set(student);
            var StudentDTO = _studentModel.Save();
            return Ok(StudentDTO);
        }
        [HttpGet]
        public IActionResult Select(string IdStudent)
        {
            Guid Id;
            if(Guid.TryParse(IdStudent, out Id)){
                var res = _studentModel.Select(Guid.Parse(IdStudent));
                return Ok(res);
            }
            else
            {
                var res = _studentModel.List();
                return Ok(res);
            }            
        }
    }
}