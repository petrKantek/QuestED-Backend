using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ITeacherMapper
    {
        /// <summary>
        /// Maps add teacher request to teacher entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>teacher entity</returns>
        Teacher Map(AddTeacherRequest request);
        /// <summary>
        /// Maps edit teacher request to teacher entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>teacher entity</returns>
        Teacher Map(EditTeacherRequest request);
        /// <summary>
        /// Maps teacher entity to teacher response
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns>teacher response</returns>
        TeacherResponse Map(Teacher teacher);
    }
}