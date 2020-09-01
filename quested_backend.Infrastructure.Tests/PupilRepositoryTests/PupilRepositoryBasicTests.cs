using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.PupilRepositoryTests
{
    public class PupilRepositoryBasicTests : IClassFixture<QuestedContextFactory>
    {
        private readonly PupilRepository _sut;
        private readonly TestQuestedContext _context;

        public PupilRepositoryBasicTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new PupilRepository(_context);
        }

        [Fact]
        public async void should_get_data()
        {
            var result = await _sut.GetAllAsync();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_be_null_invalid_id()
        {
            var result = await _sut.ReadOnlyGetByIdAsync(5);
            result.ShouldBeNull();
        }
        
        [Theory]
        [InlineData(2)]
        public async Task should_return_correct_entity(int id)
        {
            var result = await _sut.ReadOnlyGetByIdAsync(id);

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
            
            var result =  _sut.Update(testPupil);
            _sut.UnitOfWork.SaveEntitiesAsync();
            result.ShouldNotBeNull();
            result.Firstname.ShouldBe("Tomas");
        }
    }
}