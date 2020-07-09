using System.Threading;
using System.Threading.Tasks;

namespace quested_backend.Domain.Requests_DTOs
{
    public interface IRelatedEntitiesValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> TeacherExists(int teacherId, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> PupilExists(int pupilId, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SchoolExists(int schoolId, CancellationToken cancellationToken);
    }
}