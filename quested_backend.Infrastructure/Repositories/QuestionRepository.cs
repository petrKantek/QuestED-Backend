using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class QuestionRepository : EntityFrameworkRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestedContext context) : base(context)
            { }

        public async Task<IEnumerable<PupilInCourseAnswersQuestion>> GetAnswerByPrimaryKey(params int[] id)
        {
            var answer = await _context.Question
                .Include(x => x.PupilInCourseAnswersQuestion)
                .FirstOrDefaultAsync(x => x.Id == id.First() && 
                                                         x.EpisodeId == id[1] && 
                                                         x.EpisodeSeasonId == id[2]);
            
            return answer?.PupilInCourseAnswersQuestion;
        }
    }
}