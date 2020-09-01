using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface IPupilMapper
    {
        /// <summary>
        /// Maps add pupil request to pupil entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>pupil entity</returns>
        Pupil Map(AddPupilRequest request);
        /// <summary>
        /// Maps edit pupil request to pupil entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>pupil entity</returns>
        Pupil Map(EditPupilRequest request);
        /// <summary>
        /// Maps pupil entity to pupil response
        /// </summary>
        /// <param name="pupil"></param>
        /// <returns>pupil response</returns>
        PupilResponse Map(Pupil pupil);
    }
}