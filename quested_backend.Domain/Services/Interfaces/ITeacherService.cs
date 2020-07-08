using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface with the main business logic of the application. Service class provides
    /// functionality of Teachers.
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Gets all teachers in the database mapped into teacher responses
        /// </summary>
        /// <returns>IEnumerable of teacher responses </returns>
        Task<IEnumerable<TeacherResponse>> GetTeachersAsync();
        
        /// <summary>
        /// Gets teacher conforming to the get teacher request mapped into teacher response.
        /// The teacher entity itself begins to be tracked by the DB context
        /// </summary>
        /// <param name="request">object defining which teacher to get</param>
        /// <returns>teacher response</returns>
        Task<TeacherResponse> GetTeacherAsync(GetTeacherRequest request);
        
        /// <summary>
        /// Gets teacher conforming to the teacher request mapped into teacher response.
        /// The teacher entity itself is not tracked by the DB context, therefore
        /// no changes on the entity will be committed.
        /// </summary>
        /// <param name="request">object defining which teacher to get</param>
        /// <returns>teacher response</returns>
        Task<TeacherResponse> ReadOnlyGetTeacherAsync(GetTeacherRequest request);
        
        /// <summary>
        /// Adds teacher to the database with attributes of the add teacher request
        /// </summary>
        /// <param name="request">object containing attributes of teacher entity</param>
        /// <returns>added teacher mapped into a teacher response</returns>
        Task<TeacherResponse> AddTeacherAsync(AddTeacherRequest request);
        
        /// <summary>
        /// Edits attributes of existing teacher from edit teacher request
        /// </summary>
        /// <param name="request">object containing new data to be edited in existing teacher</param>
        /// <returns>edited teacher</returns>
        Task<TeacherResponse> EditTeacherAsync(EditTeacherRequest request);
        
        /// <summary>
        /// Gets score of pupil by the given request
        /// </summary>
        /// <param name="request">object containing information which score to get</param>
        /// <returns>int score</returns>
        Task<int> GetPupilScore(GetPupilScoreRequest request);
        
        /// <summary>
        /// Edits an existing score of pupil
        /// </summary>
        /// <param name="request">object containing information about pupil whose score will be edited</param>
        Task EditScore(EditScoreRequest request);
        
        /// <summary>
        /// Deletes teacher with given id permanently from database
        /// </summary>
        /// <param name="teacherId">id of teacher to be deleted</param>
        /// <returns>teacher response of the deleted teacher</returns>
        Task<TeacherResponse> DeleteTeacherById(int teacherId);
    }
}