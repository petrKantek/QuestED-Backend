using System;
using System.Threading;
using System.Threading.Tasks;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// This interface implements the Unit Of Work pattern.
    /// Unit of Work ensures that database is always in consistent
    /// state. 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves changed to database
        /// </summary>
        /// <param name="cancellationToken">token propagating information whether saving changes to the
        /// database should be cancelled</param>
        /// <returns>number of entries written to the database</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Saves changes to database
        /// </summary>
        /// <param name="cancellationToken">token propagating information whether saving changes to the
        /// database should be cancelled</param>
        /// <returns>true if changes were successfully committed, false otherwise</returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}