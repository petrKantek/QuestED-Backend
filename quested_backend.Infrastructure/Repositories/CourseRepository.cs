using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Infrastructure.Repositories
{
    public class CourseRepository : EntityFrameworkRepository<Course>, ICourseRepository
    {
        public CourseRepository(QuestedContext context) : base(context)
            { }

        public new async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _context.Set<Course>()
                .Include(course => course.PupilInCourse)
                    .ThenInclude(pupilInCourse => pupilInCourse.PupilInCourseAnswersQuestion)
                .Include(course => course.PupilInCourse)
                    .ThenInclude(pupil => pupil.Pupil)
                .Include(course => course.Teacher)
                .Include(course => course.CourseNavigation)
                .AsNoTracking()
                .ToListAsync();

            return courses;
        }

        public new async Task<Course> GetByIdAsync(int courseId)
        {
           var course = await _context.Set<Course>()
               .Include(_course => _course.PupilInCourse)
                    .ThenInclude(pupilInCourse => pupilInCourse.PupilInCourseAnswersQuestion)
               .Include(course => course.PupilInCourse)
                    .ThenInclude(pupil => pupil.Pupil)
               .Include(course => course.Teacher)
               .Include(course => course.CourseNavigation)
               .FirstOrDefaultAsync(_course => _course.Id == courseId);
           
            return course; 
        }

        public new async Task<Course> ReadOnlyGetByIdAsync(int courseId)
        {
            var course = await _context.Set<Course>()
                .Include(_course => _course.PupilInCourse)
                    .ThenInclude(pupilInCourse => pupilInCourse.PupilInCourseAnswersQuestion)
                .Include(course => course.PupilInCourse)
                    .ThenInclude(pupil => pupil.Pupil)
                .Include(course => course.Teacher)
                .Include(course => course.CourseNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(_course => _course.Id == courseId);
           
            return course; 
        }
    }
}