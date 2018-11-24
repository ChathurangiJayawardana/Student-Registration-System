using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter course's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Department Department { get; set; }
        [Required(ErrorMessage = "please enter Department name")]
        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }
        [Required(ErrorMessage ="Please enter GPA" )]
        [Display(Name="GPA")]
        public decimal GPA { get; set; }

    }
}