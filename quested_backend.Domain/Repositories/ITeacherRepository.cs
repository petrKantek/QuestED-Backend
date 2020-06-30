using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        new Task<PupilInCourseAnswersQuestion> GetAnswerByPrimaryKey(params int[] id);
        
    }
}