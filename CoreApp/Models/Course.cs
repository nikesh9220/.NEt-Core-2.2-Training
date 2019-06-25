using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using FluentValidation;

namespace CoreApp.Models
{
    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }

        public string CourseId { get; set; }
        
        public string CourseName { get; set; }
        
        public int  Capacity { get; set; }


    }
    public class NumerNoNegetiveValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) <= 0)
            {
                return false;
            }
            return true;
        }
    }
    public class RequiredValidator : AbstractValidator<Course>
    {
        public RequiredValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.CourseName))
                .WithMessage("Course Name is Required");
            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("CourseId is Required");

            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage("Capacity is Required");
            
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .LessThan(0)
                .WithMessage("Capacity should be positive only");
        }
    }
}
