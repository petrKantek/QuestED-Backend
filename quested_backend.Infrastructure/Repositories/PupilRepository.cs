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

        public new async Task<Pupil> GetByIdAsync(int id)
        {
            var pupil = await _context.Set<Pupil>()
                .Include(x => x.PupilInClass)
                .Include(x => x.PupilInCourse)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            
            return pupil;
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
    }
}