using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

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
        /// Maps pupil course to pupil response
        /// </summary>
        /// <param name="item"></param>
        /// <returns>pupil response</returns>
        PupilResponse Map(Pupil item); 
    }
}