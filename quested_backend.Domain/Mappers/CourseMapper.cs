using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Responses_DTOs;

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
                TaughtBy = HelperMapper.BasicMap(course.Teacher),
                EnrolledPupils = course.PupilInCourse
                    .Select(x => HelperMapper.BasicMap(x.Pupil))
            };

            return courseResponse;
        }
    }
}