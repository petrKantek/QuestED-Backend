using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface with the main business logic of the application. Service class provides
    /// functionality of Pupils.
    /// </summary>
    public interface IPupilService
    {
        /// <summary>
        /// Gets all pupils in the database mapped into pupil responses
        /// </summary>
        /// <returns>IEnumerable of pupil responses</returns>
        Task<IEnumerable<PupilResponse>> GetPupilsAsync();
        
        /// <summary>
        /// Gets pupil conforming to the get pupil request mapped into pupil response.
        /// The pupil entity itself begins to be tracked by the DB context
        /// </summary>
        /// <param name="request">object defining which pupil to get</param>
        /// <returns>pupil response</returns>
        Task<PupilResponse> GetPupilAsync(GetPupilRequest request);
        
        /// <summary>
        /// Gets pupil conforming to the get pupil request mapped into pupil response.
        /// The pupil entity itself is not tracked by the DB context, therefore
        /// no changes on the entity will be committed
        /// </summary>
        /// <param name="request">object defining which pupil to get</param>
        /// <returns>pupil response</returns>
        Task<PupilResponse> ReadOnlyGetPupilAsync(GetPupilRequest request);
        
        /// <summary>
        /// Adds pupil to the database with attributes of the add pupil request
        /// </summary>
        /// <param name="request">object containing attributes of pupil entity</param>
        /// <returns>added pupil mapped into a pupil response</returns>
        Task<PupilResponse> AddPupilAsync(AddPupilRequest request);
        
        /// <summary>
        /// Edits attributes of existing pupil from edit pupil request
        /// </summary>
        /// <param name="request">object containing new data to be edited in existing pupil</param>
        /// <returns>edited pupil</returns>
        Task<PupilResponse> EditPupilAsync(EditPupilRequest request);
        
        /// <summary>
        /// Deletes pupil with given id permanently from database
        /// </summary>
        /// <param name="pupilId">id of pupil to be deleted</param>
        /// <returns>pupil response of the deleted pupil</returns>
        Task<PupilResponse> DeletePupilById(int pupilId);
    }
}