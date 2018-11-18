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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Department")]
        public Department Department { get; set; }
        public byte DepartmentId { get; set; }
        [Display(Name="GPA")]
        public decimal GPA { get; set; }

    }
}