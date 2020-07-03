using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// Specific question repository.
    /// </summary>
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<IEnumerable<PupilInCourseAnswersQuestion>> GetAnswerByPrimaryKey(params int[] id);
    }
}