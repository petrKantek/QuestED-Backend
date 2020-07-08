﻿using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers
{
    public class TeacherMapper : ITeacherMapper
    {
        public Teacher Map(AddTeacherRequest request)
        {
            if (request == null) return null;

            var teacher = new Teacher
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                SchoolId = request.SchoolId,
            };

            return teacher;
        }

        public Teacher Map(EditTeacherRequest request)
        {
            if (request == null) return null;
            
            var teacher = new Teacher
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                SchoolId = request.SchoolId,
            };

            return teacher;
        }

        public TeacherResponse Map(Teacher teacher)
        {
            if (teacher == null) return null;
            
            var teacherResponse = new TeacherResponse
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname,
                TeachesCourses = teacher.Course
                    .Select(x => new CourseBasicInfo
                    {
                        Id = x.Id,
                        Name = x.Name
                    }),
                TeachesInSchool = new SchoolBasicInfo
                {
                    Id = teacher.School?.Id,
                    Name = teacher.School?.Name,
                    Country = teacher.School?.Country
                }
            };

            return teacherResponse;
        }

        public TeacherBasicInfo MapAdditionalInfo(Teacher teacher)
        {
            if (teacher == null) return null;
            
            var teacherResponse = new TeacherBasicInfo()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname,
            };

            return teacherResponse;
        }
    }
}