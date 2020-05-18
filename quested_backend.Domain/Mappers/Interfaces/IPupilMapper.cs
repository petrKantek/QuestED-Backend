using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface IPupilMapper
    {
        Pupil Map(AddPupilRequest request);
        Pupil Map(EditPupilRequest request);
        PupilResponse Map(Pupil item); 
    }
}