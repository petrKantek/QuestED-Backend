using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Entities;
using quested_backend.Infrastructure.Repositories;
using Xunit;
using Shouldly;

namespace quested_backend.Infrastructure.Tests
{
    public class PupilRepositoryTests
    {
        [Fact]
        public async void should_get_data()
        {
            var options = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestQuestedContext(options);
            context.Database.EnsureCreated();
            var sut = new EntityFrameworkRepository<Pupil, int>(context);
            var result = await sut.GetAllAsync();

            result.ShouldNotBeNull();
        }

        [Fact]
        public async void should_be_null_invalid_id()
        {
            var options = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestQuestedContext(options);
            context.Database.EnsureCreated();
            var sut = new EntityFrameworkRepository<Pupil, int>(context);
            var result = await sut.GetByIdAsync(5);

            result.ShouldBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async void should_return_correct_entity(int id)
        {
            var options = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestQuestedContext(options);
            context.Database.EnsureCreated();
            var sut = new EntityFrameworkRepository<Pupil, int>(context);
            var result = await sut.GetByIdAsync(id);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Petr");
        }

        [Fact]
        public async Task should_add_new_pupil()
        {
            var testPupil = new Pupil
            {
                Id = 4,
                Firstname = "Nirai",
                PupilInClass = null,
                PupilInCourse = null
            };
            
            var options = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestQuestedContext(options);
            context.Database.EnsureCreated();
            var sut = new EntityFrameworkRepository<Pupil, int>(context);
            sut.Create(testPupil);
            await sut.UnitOfWork.SaveEntitiesAsync();
            context.Pupil.FirstOrDefault(_ => _.Id == testPupil.Id).ShouldNotBeNull();
        }

        [Fact]
        public async void should_update_pupil()
        {
            var testPupil = new Pupil()
            {
                Id = 1,
                Firstname = "Tomas",
                PupilInClass = null,
                PupilInCourse = null,
            };
            
            var options = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;
            
            await using var context = new TestQuestedContext(options);
            context.Database.EnsureCreated();
            var sut = new EntityFrameworkRepository<Pupil, int>(context);

            sut.Update(testPupil);

            context.Pupil.FirstOrDefaultAsync(x => x.Id == testPupil.Id)
                .Result?.Firstname
                .ShouldBe("Tomas");
        }
    }
}