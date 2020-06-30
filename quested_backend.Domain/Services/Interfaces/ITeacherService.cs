using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.Pupil;
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
        Task<int> GetPupilScore(GetPupilScoreRequest request);
       // Task GetPupilsScores(int teacherId, int classId);
        Task EditScore(EditScoreRequest request);
        Task AddPupilToClass(AddPupilToClassRequest request);
        //TODO Task ImportLogFile();
        //TODO ChangeRFID();
        //TODO GetStatistics();
    }
}