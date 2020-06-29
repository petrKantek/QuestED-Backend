using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Course;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ICourseMapper
    {
        Course Map(AddCourseRequest request);
        
        Course Map(EditCourseRequest request);
        
        CourseResponse Map(Course course);
    }
}