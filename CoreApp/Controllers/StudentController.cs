using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreApp.Models;
using CoreApp.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        IService<Student, int> StudentService;

        public StudentController(IService<Student, int> StudentService)
        {
            this.StudentService = StudentService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = StudentService.GetAsync().Result;
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = StudentService.GetAsync(id).Result;
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Student Student)
        {
            var result = StudentService.CreateAsync(Student).Result;
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student Student)
        {
            var result = StudentService.UpdateAsync(id, Student).Result;
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = StudentService.DeleteAsync(id).Result;
            return Ok(result);
        }
    }
}
