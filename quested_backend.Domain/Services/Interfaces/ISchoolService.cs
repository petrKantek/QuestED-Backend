using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface with the main business logic of the application. Service class provides
    /// functionality of Schools.
    /// </summary>
    public interface ISchoolService
    {
        /// <summary>
        /// Gets all schools in the database mapped into school responses
        /// </summary>
        /// <returns>IEnumerable of school responses</returns>
        Task<IEnumerable<SchoolResponse>> GetSchoolsAsync();
        
        /// <summary>
        /// Gets school conforming to the get school request mapped into school response.
        /// The school entity itself begins to be tracked by the DB context
        /// </summary>
        /// <param name="request">object defining which school to get</param>
        /// <returns>school response</returns>
        Task<SchoolResponse> GetSchoolAsync(GetSchoolRequest request);
        
        /// <summary>
        /// Gets school conforming to the school request mapped into school response.
        /// The school entity itself is not tracked by the DB context, therefore
        /// no changes on the entity will be committed
        /// </summary>
        /// <param name="request">object defining which school to get</param>
        /// <returns>school response</returns>
        Task<SchoolResponse> ReadOnlyGetSchoolAsync(GetSchoolRequest request);
        
        /// <summary>
        /// Adds school to the database with attributes of the add school request
        /// </summary>
        /// <param name="request">object containing attributes of school entity</param>
        /// <returns>added school mapped into a school response</returns>
        Task<SchoolResponse> AddSchoolAsync(AddSchoolRequest request);
        
        /// <summary>
        /// Edits attributes of existing school from edit school request
        /// </summary>
        /// <param name="request">object containing new data to be edited in existing school</param>
        /// <returns>edited school</returns>
        Task<SchoolResponse> EditSchoolAsync(EditSchoolRequest request);

        /// <summary>
        /// Assigns existing teacher to school
        /// </summary>
        /// <param name="request">object specifying which teacher to assign to a school</param>
        Task AddTeacherToSchool(AddTeacherToSchoolRequest request);
        
        
        //TODO soft deletion
    }
}