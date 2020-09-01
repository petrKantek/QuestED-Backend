using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class ClassRepository : EntityFrameworkRepository<Class>, IClassRepository
    {
        public ClassRepository(QuestedContext context) : base(context)
            { }

        public new async Task<IEnumerable<Class>> GetAllAsync()
        {
            var classes = await _context.Set<Class>()
                .Include(x => x.Teacher)
                .Include(x => x.PupilInClass)
                    .ThenInclude(y => y.Pupil)
                .AsNoTracking()
                .ToListAsync();

            return classes;
        }

        public new async Task<Class> GetByIdAsync(int id)
        {
            var _class = await _context.Set<Class>()
                .Include(x => x.Teacher)
                .Include(x => x.PupilInClass)
                    .ThenInclude(y => y.Pupil)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _class;
        }

        public new async Task<Class> ReadOnlyGetByIdAsync(int id)
        {
            var _class = await _context.Set<Class>()
                .Include(x => x.Teacher)
                .Include(x => x.PupilInClass)
                    .ThenInclude(y => y.Pupil)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return _class;
        }
    }
}