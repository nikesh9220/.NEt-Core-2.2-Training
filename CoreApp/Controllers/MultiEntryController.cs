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
    [ApiController ]
    public class MultiEntryController : Controller
    {
        IService<Student, int> StudentService;
        IService<Course, int> courseService;
        public MultiEntryController(IService<Course, int> courseService, IService<Student, int> StudentService)
        {
            this.StudentService = StudentService;
            this.courseService = courseService;
        }   
            
        [HttpPost]
        public IActionResult Post(CourseStudentViewModel courseStudents)
        {
            var result = courseService.CreateAsync(courseStudents.course).Result;
            foreach (var std in courseStudents.students)
            {
                StudentService.CreateAsync(std);
            }
            return null;
        }
    }
    
}
