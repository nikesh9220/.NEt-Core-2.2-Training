using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class CourseStudentViewModel
    {
        public Course course { get; set; }
        public List<Student> students { get; set; }
    }
}
