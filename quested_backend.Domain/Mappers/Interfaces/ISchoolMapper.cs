using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ISchoolMapper
    {
        School Map(AddSchoolRequest request);
        
        School Map(EditSchoolRequest request);
        
        SchoolResponse Map(School school);
    }
}