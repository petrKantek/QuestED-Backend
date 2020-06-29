using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Course;
using quested_backend.Domain.Responses;

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
                SeasonId = request.SeasonId
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
                SeasonId = request.SeasonId
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
                TeacherId = course.TeacherId,
                SeasonId = course.SeasonId
            };

            return courseResponse;
        }
    }
}