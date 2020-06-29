using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherResponse>> GetTeachersAsync();
        Task<TeacherResponse> GetTeacherAsync(GetTeacherRequest request);
        Task<TeacherResponse> ReadOnlyGetTeacherAsync(GetTeacherRequest request);
        Task<TeacherResponse> AddTeacherAsync(AddTeacherRequest request);
        Task<TeacherResponse> EditTeacherAsync(EditTeacherRequest request);
        Task GetPupilsScores(int teacherId, int classId);
        Task ChangeScore(int pupilId);
        Task AddPupilToClass(int pupilId, int classId);
        //TODO Task ImportLogFile();
        //TODO ChangeRFID();
        //TODO GetStatistics();
    }
}