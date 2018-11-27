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
        public IHttpActionResult GetStudents()
        {
          var studentDtos= _context.Students.ToList().Select(Mapper.Map<Student,StudentDto>);
            return Ok(studentDtos);
        }

        //GET /api/studentrs/1
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok( Mapper.Map<Student,StudentDto>(student));
        }

        //POST /api/students
        [HttpPost]
        public IHttpActionResult CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;
            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);
        }
        //PUT /api/students/1
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id,StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
                return NotFound();

            Mapper.Map(studentDto, studentInDb);
         

            _context.SaveChanges();
            return Ok();
        }
        // DELETE /api/students/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(c => c.Id == id);
            if (studentInDb == null)
                return NotFound();

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
