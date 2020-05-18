using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Xunit;
using Shouldly;

namespace quested_backend.Infrastructure.Tests
{
    public class PupilRepositoryTests : IClassFixture<QuestedContextFactory>
    {

        private readonly EntityFrameworkRepository<Pupil, int> _sut;
        private readonly TestQuestedContext _context;

        public PupilRepositoryTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new EntityFrameworkRepository<Pupil, int>(_context);
        }

        [Fact]
        public async void should_get_data()
        {
            var result = await _sut.GetAllAsync();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async void should_be_null_invalid_id()
        {
            var result = await _sut.GetByIdAsync(5);
            result.ShouldBeNull();
        }
        
        [Theory]
        [InlineData(2)]
        public async void should_return_correct_entity(int id)
        {
            var result = await _sut.GetByIdAsync(id);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Stanislav");
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
            
            _sut.Create(testPupil);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            
            _context.Pupil
                .FirstOrDefault(_ => _.Id == testPupil.Id)
                .ShouldNotBeNull();
        }

        [Fact]
        public void should_update_pupil()
        {
            var testPupil = new Pupil()
            {
                Id = 1,
                Firstname = "Tomas",
                PupilInClass = null,
                PupilInCourse = null,
            };

               var result = _sut.Update(testPupil);

           result.Firstname.ShouldBe("Tomas");
        }
    }
}