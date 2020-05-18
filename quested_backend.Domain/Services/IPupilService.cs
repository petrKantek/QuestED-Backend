using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services
{
    public interface IPupilService
    {
        Task<IEnumerable<PupilResponse>> GetItemsAsync();
        Task<PupilResponse> GetItemAsync(GetPupilRequest request);
        Task<PupilResponse> AddItemAsync(AddPupilRequest request);
        Task<PupilResponse> EditItemAsync(EditPupilRequest request);
     //   Task<PupilResponse> DeleteItemAsync(DeletePupilRequest request);
    }
}