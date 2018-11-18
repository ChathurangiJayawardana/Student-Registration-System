using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter student's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name="Index Number")]
        public string IndexNo { get; set; }
        [Display(Name="Register Date")]
        public DateTime? RegisterDate { get; set; }
        
        [Display(Name="Degree Name")]
        public AcademicType AcademicType { get; set; }
        [Required(ErrorMessage = "Please enter Degree Name")]
        public byte AcademicTypeId { get; set; }
    }
}