using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ICourseMapper
    {
        /// <summary>
        /// Maps add course request to course entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>course entity</returns>
        Course Map(AddCourseRequest request);
        /// <summary>
        /// Maps edit course request to course entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>course entity</returns>
        Course Map(EditCourseRequest request);
        /// <summary>
        /// Maps course entity to course response
        /// </summary>
        /// <param name="course"></param>
        /// <returns>course response</returns>
        CourseResponse Map(Course course);
    }
}