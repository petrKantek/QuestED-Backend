using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class PupilRepository : EntityFrameworkRepository<Pupil>, IPupilRepository
    {
        public PupilRepository(QuestedContext context) : base(context)
            { }

        public new async Task<IEnumerable<Pupil>> GetAllAsync()
        {
            var pupils = await _context.Set<Pupil>()
                .Include(x => x.PupilInClass)
                    .ThenInclude(y => y.Class)
                .Include(x => x.PupilInCourse)
                    .ThenInclude(y => y.Course)
                .Include(x => x.PupilInCourse)
                    .ThenInclude(y => y.PupilInCourseAnswersQuestion)
                .AsNoTracking()
                .ToListAsync();

            return pupils;
        }

        public  async Task<Pupil> GetByIdAsync(int id, IEnumerable<string> includes)
        {
            var pupil = await _context.Set<Pupil>()
                .Include(x => x.PupilInClass)
                    .ThenInclude(y => y.Class)
                .Include(x => x.PupilInCourse)
                    .ThenInclude(y => y.Course)
                .Include(x => x.PupilInCourse)
                    .ThenInclude(y => y.PupilInCourseAnswersQuestion)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return pupil;
        }

        public new async Task<Pupil> ReadOnlyGetByIdAsync(int id)
        {
            var pupil = 
                await _context.Set<Pupil>()
                    .Include(x => x.PupilInClass)
                        .ThenInclude(y => y.Class)
                    .Include(x => x.PupilInCourse)
                        .ThenInclude(y => y.Course)
                    .Include(x => x.PupilInCourse)
                        .ThenInclude(y => y.PupilInCourseAnswersQuestion)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            return pupil;
        }
    }
}