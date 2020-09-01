using System.Threading;
using System.Threading.Tasks;

namespace quested_backend.Domain.Requests_DTOs
{
    public interface IRelatedEntitiesValidator
    {
        /// <summary>
        /// Verifies that teacher with teacherId exists in the database
        /// </summary>
        /// <param name="teacherId">id of teacher to be verified</param>
        /// <param name="cancellationToken"></param>
        /// <returns>true if teacher exists, false otherwise</returns>
        Task<bool> TeacherExists(int teacherId, CancellationToken cancellationToken);

        /// <summary>
        /// Verifies that pupil with pupilId exists in the database
        /// </summary>
        /// <param name="pupilId">id of pupil to be verified</param>
        /// <param name="cancellationToken"></param>
        /// <returns>true if pupil exists, false otherwise</returns>
        Task<bool> PupilExists(int pupilId, CancellationToken cancellationToken);

        /// <summary>
        /// Verifies that school with schoolId exists in the database
        /// </summary>
        /// <param name="schoolId">id of school to be verified</param>
        /// <param name="cancellationToken"></param>
        /// <returns>true if school exists, false otherwise</returns>
        Task<bool> SchoolExists(int schoolId, CancellationToken cancellationToken);
    }
}