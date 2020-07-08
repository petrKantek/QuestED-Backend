using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly QuestedContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public EntityFrameworkRepository(QuestedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TEntity Create(TEntity entity)
        {
           return _context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public async Task<TEntity> ReadOnlyGetByIdAsync(int id)
        {
           var item = 
               await _context.Set<TEntity>()
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == id);

           return item;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var item = await _context.Set<TEntity>().FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> DeleteById(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Entity with ID {id} does not exist in the database");
            }

            Delete(entity);
            return entity;
        }
    }
}