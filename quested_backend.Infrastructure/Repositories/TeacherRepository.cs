using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class TeacherRepository : EntityFrameworkRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(QuestedContext context) : base(context)
            { }

        public new async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var teachers = await _context.Set<Teacher>()
                .Include(x => x.Class)
                .Include(x => x.Course)
                .Include(x => x.School)
                .AsNoTracking()
                .ToListAsync();

            return teachers;
        }
        
        public new async Task<Teacher> GetByIdAsync(int teacherId)
        {
            var teacher = await _context.Set<Teacher>()
                .Include(x => x.Class)
                .Include(x => x.Course)
                .Include(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == teacherId);

            return teacher;
        }
        
        public new async Task<Teacher> ReadOnlyGetByIdAsync(int teacherId)
        {
            var teacher = await _context.Set<Teacher>()
                .Include(x => x.Class)
                .Include(x => x.Course)
                .Include(x => x.School)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == teacherId);

            return teacher;
        }
        
        public async Task<PupilInCourseAnswersQuestion> GetAnswerByPrimaryKey(params int[] id)
        {
            if (id.Length != 5)
            {
                throw new ArgumentException("Question answers has a composite 5-part primary key, " +
                                            "you have to provide all parts in correct order");
            }

            var result  = await _context.Set<PupilInCourseAnswersQuestion>()
                .FindAsync(id[0],id[1],id[2],id[3],id[4]);
           
            return result;
        }
    }
}