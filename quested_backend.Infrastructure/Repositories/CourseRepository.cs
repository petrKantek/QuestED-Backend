using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class CourseRepository : EntityFrameworkRepository<Course>, ICourseRepository
    {
        public CourseRepository(QuestedContext context) : base(context)
            { }

        public async Task<Course> GetCourseWithAnswers(int courseId)
        {
            var course = await _context.Set<Course>()
                .Include(_course => _course.PupilInCourse)
                .ThenInclude(pupilInCourse => pupilInCourse.PupilInCourseAnswersQuestion)
                .FirstOrDefaultAsync(_course => _course.Id == courseId);

            return course;
        }
    }
}