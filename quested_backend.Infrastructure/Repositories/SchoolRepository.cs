using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class SchoolRepository : EntityFrameworkRepository<School>, ISchoolRepository
    {
        public SchoolRepository(QuestedContext context) : base(context)
            { }

        public new async Task<IEnumerable<School>> GetAllAsync()
        {
            var schools = await _context.Set<School>()
                .Include(x => x.Teacher)
                .Include(x => x.SchoolOwnsSeason)
                    .ThenInclude(x => x.Season)
                .AsNoTracking()
                .ToListAsync();

            return schools;
        }

        public new async Task<School> GetByIdAsync(int schoolId)
        {
            var school = await _context.Set<School>()
                .Include(x => x.Teacher)
                .Include(x => x.SchoolOwnsSeason)
                     .ThenInclude(x => x.Season)
                .FirstOrDefaultAsync(x => x.Id == schoolId);

            return school;
        }
        
        public new async Task<School> ReadOnlyGetByIdAsync(int schoolId)
        {
            var school = await _context.Set<School>()
                .Include(x => x.Teacher)
                .Include(x => x.SchoolOwnsSeason)
                     .ThenInclude(x => x.Season)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == schoolId);

            return school;
        }
    }
}