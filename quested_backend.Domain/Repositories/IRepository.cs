using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// Generic interface implementing the Repository pattern.
    /// It provides the communication point with the database.
    /// It serves as a collection of objects representing rows in
    /// tables, therefore it does not itself commit any changes to
    /// the database(just like a normal collection). The changes
    /// have to be explicitly committed via UnitOfWork.
    /// Entity-specific interfaces(classes) can inherit from this
    /// class to add or overwrite special behavior. 
    /// </summary>
    /// <typeparam name="TEntity">
    /// Specifies the entity for which the repository operates
    /// </typeparam>
    public interface IRepository <TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        
        Task<TEntity> ReadOnlyGetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Delete(TEntity entity);

        Task<TEntity> DeleteById(int id);
    }
}