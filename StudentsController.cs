using StudentRegistrationApplication.Models;
using StudentRegistrationApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationApplication.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var academicTypes = _context.AcademicTypes.ToList();
            var viewModel = new NewStudentViewModel
            {
                AcademicTypes = academicTypes
            };
            return View("New", viewModel);
        }
        // GET: Students
        public ViewResult Index()
        {
            var students = _context.Students.Include(c =>c.AcademicType).ToList();
            return View(students);
        }
        public ActionResult Details(int id)
        {
            var student = _context.Students.Include(c => c.AcademicType).SingleOrDefault(c => c.Id == id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
    }
}