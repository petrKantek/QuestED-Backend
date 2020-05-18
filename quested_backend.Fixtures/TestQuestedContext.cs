using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures.Extensions;
using quested_backend.Infrastructure;

namespace quested_backend.Fixtures
{
    public class TestQuestedContext : QuestedContext
    {
        public TestQuestedContext(DbContextOptions<QuestedContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<Pupil>("./Data/pupil.json");
        }

       
    }
}