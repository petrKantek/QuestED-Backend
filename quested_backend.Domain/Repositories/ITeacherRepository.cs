using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// Specific teacher repository.
    /// </summary>
    public interface ITeacherRepository : IRepository<Teacher>
    {
        /// <summary>
        /// Gets pupil's answer based on primary key obtained from an array of ints.
        /// </summary>
        /// <param name="id">int array representing primary key</param>
        /// <returns>answer entity if primary key is valid, null otherwise</returns>
        new Task<PupilInCourseAnswersQuestion> GetAnswerByPrimaryKey(params int[] id);
    }
}