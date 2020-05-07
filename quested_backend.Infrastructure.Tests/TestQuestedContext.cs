using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Repositories;
using quested_backend.Entities;
using quested_backend.Infrastructure.Tests.Extensions;

namespace quested_backend.Infrastructure.Tests
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