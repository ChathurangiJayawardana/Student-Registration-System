using StudentRegistrationApplication.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationApplication.ViewModels;

namespace StudentRegistrationApplication.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            var viewModel = new CourseFormViewModel
            {
                Course = course,
                Departments = _context.Departments.ToList()
            };
            return View("CourseForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
           if(!ModelState.IsValid)
            {
                var viewModel = new CourseFormViewModel
                {
                    Course = course,
                    Departments=_context.Departments.ToList()

                };

                return View("CourseForm", viewModel);
            }
            if (course.Id == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.Id == course.Id);

                courseInDb.Name = course.Name;
                courseInDb.DepartmentId = course.DepartmentId;
                courseInDb.GPA = course.GPA;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
        public ViewResult CourseForm()
        {
            var departments = _context.Departments.ToList();
            var viewModel = new CourseFormViewModel
            {
                Departments = departments
            };
            return View("CourseForm", viewModel);
        }

        // GET: Courses
        public ViewResult Index()
        {

            var courses = _context.Courses.Include(m => m.Department).ToList();
            return View(courses);
        }
        public ActionResult Details(int id)
        {
            var course = _context.Courses.Include(m => m.Department).SingleOrDefault(m => m.Id == id);
            if (course == null)


                return HttpNotFound();

            return View(course);
        }
    }

}