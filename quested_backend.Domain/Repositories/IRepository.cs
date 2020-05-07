using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quested_backend.Domain.Repositories
{
    public interface IRepository <TEntity, TKey> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Delete(TEntity entity);

        void DeleteById(TKey id);
    }
}