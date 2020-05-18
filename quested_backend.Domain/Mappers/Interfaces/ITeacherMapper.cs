using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface ITeacherMapper
    {
        Teacher Map(AddTeacherRequest request);
        
        Teacher Map(EditTeacherRequest request);
        
        TeacherResponse Map(Teacher teacher);
    }
}