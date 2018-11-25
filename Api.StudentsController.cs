using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentRegistrationApplication.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/students
        public IEnumerable<Student>GetStudents()
        {
            return _context.Students.ToList();
        }

        //GET /api/studentrs/1
        public Student GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return student;
        }

        //POST /api/students
        [HttpPost]
        public Student CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }
        //PUT /api/students/1
        public void UpdateStudent(int id,Student student)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            studentInDb.Name = student.Name;
            studentInDb.IndexNo = student.IndexNo;
            studentInDb.RegisterDate = student.RegisterDate;
            studentInDb.AcademicTypeId = student.AcademicTypeId;

            _context.SaveChanges();
        }
        // DELETE /api/students/1
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
        }
    }
}
