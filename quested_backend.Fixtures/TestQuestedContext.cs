using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures.Extensions;
using quested_backend.Infrastructure;

namespace quested_backend.Fixtures
{
    /// <summary>
    /// Same as QuestedContext, just used for testing with test data
    /// </summary>
    public class TestQuestedContext : QuestedContext
    {
        public TestQuestedContext(DbContextOptions<QuestedContext> options) : base(options)
            {}

        /// <summary>
        /// Seeds the testing in-memory database with test data from ./Data folder
        /// </summary>
        /// <param name="modelBuilder"> API enabling modification of our DB context </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedDatabase();
        }
    }
}