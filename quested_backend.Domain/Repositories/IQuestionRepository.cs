using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// Specific Question repository
    /// </summary>
    public interface IQuestionRepository : IRepository<Question>
    {
        /// <summary>
        /// Gets all answers for given question
        /// </summary>
        /// <param name="id">composite primary key of question</param>
        /// <returns>IEnumerable of answers</returns>
        public Task<IEnumerable<PupilInCourseAnswersQuestion>> GetAnswerByPrimaryKey(params int[] id);
    }
}