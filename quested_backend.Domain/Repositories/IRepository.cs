using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    public interface IRepository <TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        
        Task<TEntity> ReadOnlyGetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Delete(TEntity entity);

        void DeleteById(int id);
    }
}