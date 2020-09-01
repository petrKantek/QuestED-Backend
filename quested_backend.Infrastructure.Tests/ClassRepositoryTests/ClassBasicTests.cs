using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.ClassRepositoryTests
{
    public class ClassBasicTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly EntityFrameworkRepository<Class> _sut;
        
        public ClassBasicTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new EntityFrameworkRepository<Class>(_context);
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
            result.Name.ShouldBe("C2");
            result.TeacherId.ShouldBe(2);
        }
        
        [Fact]
        public async Task should_add_new_class()
        {
            var testClass = new Class
            {
                Id = 4,
                Name = "C4",
                TeacherId = 1,
                PupilInClass = null,
            };
            
            _sut.Create(testClass);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var addedClass = _context.Class
                .FirstOrDefault(_ => _.Id == testClass.Id);
            
            addedClass.ShouldNotBeNull();
            addedClass.Id.ShouldBe(testClass.Id);
            addedClass.Name.ShouldBe(testClass.Name);
            addedClass.TeacherId.ShouldBe(testClass.TeacherId);
        }
        
        [Fact]
        public void should_update_class()
        {
            var testClass = new Class()
            {
                Id = 1,
                Name = "A1",
                TeacherId =  3,
                Teacher =  null,
                PupilInClass = null
            };

            var updatedClass =  _sut.Update(testClass);

           updatedClass.ShouldNotBeNull();
           updatedClass.Id.ShouldBe(testClass.Id);
           updatedClass.Name.ShouldBe(testClass.Name);
           updatedClass.TeacherId.ShouldBe(testClass.TeacherId);
        }
    }
}