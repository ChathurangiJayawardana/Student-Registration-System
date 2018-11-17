using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Models
{
    public class Department
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; }
    }
}