using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        public Task<Course> GetCourseWithAnswers(int courseId);
    }
}