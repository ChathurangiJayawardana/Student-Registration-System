﻿using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    
        public string IndexNo { get; set; }
        
        public DateTime? RegisterDate { get; set; }

        public byte AcademicTypeId { get; set; }

        public AcademicTypeDto AcademicType { get; set; }
    }
}