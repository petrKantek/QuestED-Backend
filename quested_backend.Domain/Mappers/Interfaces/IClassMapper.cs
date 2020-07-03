using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface IClassMapper
    {
        /// <summary>
        /// Maps add class request to class entity 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>class entity</returns>
        Class Map(AddClassRequest request);
        
        /// <summary>
        /// Maps edit class request to class entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>class entity</returns>
        Class Map(EditClassRequest request);
        
        /// <summary>
        /// Maps class entity to class reponse
        /// </summary>
        /// <param name="_class"></param>
        /// <returns>class response</returns>
        ClassResponse Map(Class _class);
    }
}