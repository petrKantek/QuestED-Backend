using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers
{
    public class CourseMapper : ICourseMapper
    {
        public Course Map(AddCourseRequest request)
        {
            if (request == null) return null;

            var course = new Course
            {
                Name = request.Name,
                TeacherId =  request.TeacherId,
                CourseId = request.SeasonId
            };

            return course;
        }

        public Course Map(EditCourseRequest request)
        {
            if (request == null) return null;
            
            var course = new Course
            {
                Id = request.Id,
                Name = request.Name,
                TeacherId =  request.TeacherId,
                CourseId = request.SeasonId
            };

            return course;
        }

        public CourseResponse Map(Course course)
        {
            if (course == null) return null;

            var courseResponse = new CourseResponse
            {
                Id = course.Id,
                Name = course.Name,
                TaughtInSeason = course.CourseNavigation?.Name,
                TaughtBy = new TeacherBasicInfo
                {
                    Id = course.Teacher?.Id,
                    Firstname = course.Teacher?.Firstname,
                    Lastname = course.Teacher?.Lastname
                },
                EnrolledPupils = course.PupilInCourse
                    .Select(x => new PupilBasicInfo
                    {
                        Id = x.Pupil?.Id,
                        Firstname = x.Pupil?.Firstname
                    })
            };

            return courseResponse;
        }

        public CourseBasicInfo MapAdditionalInfo(Course course)
        {
            if (course == null) return null;

            var courseResponse = new CourseBasicInfo()
            {
                Id = course.Id,
                Name = course.Name,
            };

            return courseResponse;
        }
    }
}