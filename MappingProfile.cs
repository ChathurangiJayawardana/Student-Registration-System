using AutoMapper;
using StudentRegistrationApplication.Dtos;
using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<AcademicType, AcademicTypeDto>();

            //Dto to Domain
            Mapper.CreateMap<StudentDto, Student>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<CourseDto, Course>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}