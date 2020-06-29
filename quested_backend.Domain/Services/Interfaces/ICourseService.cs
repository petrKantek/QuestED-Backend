using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Course;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponse>> GetCoursesAsync();
        Task<CourseResponse> GetCourseAsync(GetCourseRequest request);
        Task<CourseResponse> ReadOnlyGetCourseAsync(GetCourseRequest request);
        Task<CourseResponse> AddCourseAsync(AddCourseRequest request);
        Task<CourseResponse> EditCourseAsync(EditCourseRequest request);
    }
}