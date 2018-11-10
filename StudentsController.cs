using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationApplication.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ViewResult Index()
        {
            var students = GetStudents();
            return View(students);
        }
        public ActionResult Details(int id)
        {
            var student = GetStudents().SingleOrDefault(c => c.Id == id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
        private IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student {Id=1, Name="Abeyrathne K.L.M."},
                new Student {Id=2, Name="Bandara M.Y."},
                new Student{Id=3,Name="De silva A.R."},
                new Student{Id=4,Name="Ekanayake T.D."}
            };
        }
    }
}