using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.SchoolRepositoryTests
{
    public class SchoolBasicTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly EntityFrameworkRepository<School> _sut;

        public SchoolBasicTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new EntityFrameworkRepository<School>(_context);
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
            var result = await _sut.ReadOnlyGetByIdAsync(20);
            result.ShouldBeNull();
        }
        
        [Theory]
        [InlineData(2)]
        public async Task should_return_correct_entity(int id)
        {
            var result = await _sut.ReadOnlyGetByIdAsync(id);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("BOKU");
            result.Country.ShouldBe("Austria");
        }
        
        [Fact]
        public async Task should_add_new_school()
        {
            var testSchool = new School
            {
                Id = 4,
                Name = "MUNI",
                Country = "CZE",
                SchoolOwnsSeason = null,
                Teacher = null
            };
            
            _sut.Create(testSchool);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var addedSchool = _context.School
                .FirstOrDefault(_ => _.Id == testSchool.Id);
            
            addedSchool.ShouldNotBeNull();
            addedSchool.Id.ShouldBe(testSchool.Id);
            addedSchool.Name.ShouldBe(testSchool.Name);
            addedSchool.Country.ShouldMatch(testSchool.Country);
        }
        
        [Fact]
        public void should_update_school()
        {
            var testSchool = new School()
            {
                Id = 1,
                Name = "Angewandte",
                Country = "Germany",
                SchoolOwnsSeason = null,
                Teacher = null
            };

            var result =  _sut.Update(testSchool);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(testSchool.Id);
            result.Name.ShouldBe(testSchool.Name);
            result.Country.ShouldBe(testSchool.Country);
        }
    }
}