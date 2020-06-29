using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassResponse>> GetClassesAsync();
        Task<ClassResponse> GetClassAsync(GetClassRequest request);
        Task<ClassResponse> ReadOnlyGetClassAsync(GetClassRequest request);
        Task<ClassResponse> AddClassAsync(AddClassRequest request);
        Task<ClassResponse> EditClassAsync(EditClassRequest request);
        
        //TODO soft deletion
    }
}