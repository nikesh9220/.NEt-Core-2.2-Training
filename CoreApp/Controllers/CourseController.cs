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
    public class CourseController : ControllerBase
    {
        IService<Course, int> courseService;
        
        public CourseController(IService<Course, int> courseService)
        {
            this.courseService = courseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = courseService.GetAsync().Result;
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = courseService.GetAsync(id).Result;
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Course course)
        {
            var result = courseService.CreateAsync(course).Result;
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Course course)
        {
            var result = courseService.UpdateAsync(id,course).Result;
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = courseService.DeleteAsync(id).Result;
            return Ok(result);
        }
    }
}
