using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.ViewModels
{
    public class CourseFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }


        public Course Course { get; set; }
    }
}