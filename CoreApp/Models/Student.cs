using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CoreApp.Models
{
    public class Student
    {
        [Key]
        public int StudentRowId { get; set; }
        
        [Required(ErrorMessage = "Student Id is Required")]
        public string StudentId { get; set; }
       
        [Required(ErrorMessage = "StudentName is Required")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Address is Required")] 
        public string Address { get; set; }
        
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "CourseRow Id is Required")]
        public int CourseRowId { get; set; }
        
        public Course Course { get; set; }


    }
}
