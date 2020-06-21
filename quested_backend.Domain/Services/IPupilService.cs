using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services
{
    public interface IPupilService
    {
        Task<IEnumerable<PupilResponse>> GetPupilsAsync();
        Task<PupilResponse> GetPupilAsync(GetPupilRequest request);
        Task<PupilResponse> AddPupilAsync(AddPupilRequest request);
        Task<PupilResponse> EditPupilAsync(EditPupilRequest request);
     // TODO  soft deletion - Task<PupilResponse> DeleteItemAsync(DeletePupilRequest request); 
    }
}