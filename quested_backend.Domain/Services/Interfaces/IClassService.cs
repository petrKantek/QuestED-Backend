using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface with the main business logic of the application. Service class provides
    /// functionality of Classes.
    /// </summary>
    public interface IClassService
    {
        /// <summary>
        /// Gets all classes in the database mapped into class responses
        /// </summary>
        /// <returns>IEnumerable of class responses </returns>
        Task<IEnumerable<ClassResponse>> GetClassesAsync();
        
        /// <summary>
        /// Gets class conforming to the class request mapped into class response.
        /// The class entity itself begins to be tracked by the DB context
        /// </summary>
        /// <param name="request">object defining which class to get</param>
        /// <returns>class response</returns>
        Task<ClassResponse> GetClassAsync(GetClassRequest request);
        
        /// <summary>
        /// Gets class conforming to the class request mapped into class response.
        /// The class entity itself is not tracked by the DB context, therefore
        /// no changes on the entity will be committed.
        /// </summary>
        /// <param name="request">object defining which class to get</param>
        /// <returns>class response</returns>
        Task<ClassResponse> ReadOnlyGetClassAsync(GetClassRequest request);
        
        /// <summary>
        /// Adds class to the database with attributes of the add class request
        /// </summary>
        /// <param name="request">object containing attributes of class entity</param>
        /// <returns>added class mapped into a class response</returns>
        Task<ClassResponse> AddClassAsync(AddClassRequest request);
        
        /// <summary>
        /// Edits attributes of existing class from edit class request
        /// </summary>
        /// <param name="request">object containing new data to be edited in existing class</param>
        /// <returns>edited class</returns>
        Task<ClassResponse> EditClassAsync(EditClassRequest request);

        /// <summary>
        /// Permanently deletes class with given id from database
        /// </summary>
        /// <param name="classId">id of class to be deleted</param>
        /// <returns>class response of deleted class</returns>
        Task<ClassResponse> DeleteClassById(int classId);
        
        /// <summary>
        /// Adds pupil to class
        /// </summary>
        /// <param name="request">object containing information about class and pupil</param>
        Task AddPupilToClass(AddPupilToClassRequest request);
    }
}