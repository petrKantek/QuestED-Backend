using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ISchoolMapper
    {
        /// <summary>
        /// Maps add school request to school entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>school entity</returns>
        School Map(AddSchoolRequest request);
        /// <summary>
        /// Maps edit school request to school entity 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>school entity</returns>
        School Map(EditSchoolRequest request);
        /// <summary>
        /// Maps school entity to school response 
        /// </summary>
        /// <param name="school"></param>
        /// <returns>school response</returns>
        SchoolResponse Map(School school);
    }
}