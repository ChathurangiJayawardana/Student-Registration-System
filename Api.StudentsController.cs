using AutoMapper;
using StudentRegistrationApplication.Dtos;
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
        public IEnumerable<StudentDto>GetStudents()
        {
            return _context.Students.ToList().Select(Mapper.Map<Student,StudentDto>);
        }

        //GET /api/studentrs/1
        public StudentDto GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Student,StudentDto>(student);
        }

        //POST /api/students
        [HttpPost]
        public StudentDto CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;
            return studentDto;
        }
        //PUT /api/students/1
        [HttpPut]
        public void UpdateStudent(int id,StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(studentDto, studentInDb);
         

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
