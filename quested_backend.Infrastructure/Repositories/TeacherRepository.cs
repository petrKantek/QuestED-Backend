using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class TeacherRepository : EntityFrameworkRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(QuestedContext context) : base(context)
            { }
        
        public async Task<PupilInCourseAnswersQuestion> GetAnswerByPrimaryKey(params int[] id)
        { 
            var result= 
                         await _context.PupilInCourseAnswersQuestion.FindAsync(id);
         
            return result;
        }
    }
}