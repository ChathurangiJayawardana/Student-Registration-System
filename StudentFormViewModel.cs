using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.ViewModels
{
    public class StudentFormViewModel
    {
        public IEnumerable<AcademicType> AcademicTypes { get; set; }
        public Student Student { get; set; }
    }
}