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
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/Courses
        public IHttpActionResult GetCourses()
        {
            var courseDtos = _context.Courses.ToList().Select(Mapper.Map<Course, CourseDto>);
            return Ok(courseDtos);
        }

        //GET /api/courses/1
        public IHttpActionResult GetCourse(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Course, CourseDto>(course));
        }

        //POST /api/courses
        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = Mapper.Map<CourseDto, Course>(courseDto);
            _context.Courses.Add(course);
            _context.SaveChanges();

            courseDto.Id = course.Id;
            return Created(new Uri(Request.RequestUri + "/" + course.Id), courseDto);
        }
        //PUT /api/courses/1
        [HttpPut]
        public IHttpActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDb == null)
                return NotFound();

            Mapper.Map(courseDto, courseInDb);


            _context.SaveChanges();
            return Ok();
        }
        // DELETE /api/courses/1
        [HttpDelete]
        public IHttpActionResult DeleteCourse(int id)
        {
            var CourseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (CourseInDb == null)
                return NotFound();

            _context.Courses.Remove(CourseInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
