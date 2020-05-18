using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface IClassMapper
    {
        Class Map(AddClassRequest request);
        
        Class Map(EditClassRequest request);
        
        ClassResponse Map(Class _class);
    }
}