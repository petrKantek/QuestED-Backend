using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolResponse>> GetSchoolsAsync();
        Task<SchoolResponse> GetSchoolAsync(GetSchoolRequest request);
        Task<SchoolResponse> ReadOnlyGetSchoolAsync(GetSchoolRequest request);
        Task<SchoolResponse> AddSchoolAsync(AddSchoolRequest request);
        Task<SchoolResponse> EditSchoolAsync(EditSchoolRequest request);
        
        //TODO soft deletion
    }
}