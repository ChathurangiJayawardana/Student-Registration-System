using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Dtos
{
    public class CourseDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Department Department { get; set; }

        [Required]
        public byte DepartmentId { get; set; }

        [Required]
        public decimal GPA { get; set; }
    }
}