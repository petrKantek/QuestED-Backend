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

        public new async Task<Pupil> GetByIdAsync(int id, IEnumerable<string> includes)
        {
            var pupil = _context.Set<Pupil>();

            foreach (var incl in includes)
            {
                pupil.Include(incl);
            }    
                // .Include(x => x.PupilInClass)
                // .Include(x => x.PupilInCourse)
              //  .FirstOrDefaultAsync(x => x.Id == id);
            
            return await pupil.FirstOrDefaultAsync(x => x.Id == id);
        }

        public new async Task<Pupil> ReadOnlyGetByIdAsync(int id)
        {
            var item = 
                await _context.Set<Pupil>()
                    .Include(x => x.PupilInClass)
                    .Include(x => x.PupilInCourse)
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

            return item;
        }

        public async Task<Pupil> GetPupilWithAnswers(int pupilId)
        {
            var answers = await _context.Set<Pupil>()
                .Include(pupil => pupil.PupilInCourse)
                .ThenInclude(pupilInCourse => pupilInCourse.PupilInCourseAnswersQuestion)
                .Where(pupil => pupil.Id == pupilId)
                .FirstOrDefaultAsync();

            return answers;
        }
    }
}