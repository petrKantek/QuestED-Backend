using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.TeacherRepositoryTests
{
    public class TeacherBasicTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly EntityFrameworkRepository<Teacher> _sut;
        
        public TeacherBasicTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new EntityFrameworkRepository<Teacher>(_context);
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
            result.Firstname.ShouldBe("Alexandria");
            result.Lastname.ShouldBe("Cortez");
            result.SchoolId.ShouldBe(2);
        }
        
        [Fact]
        public async Task should_add_new_teacher()
        {
            var testTeacher = new Teacher
            {
                Id = 4,
                Firstname = "Geralt",
                Lastname = "Of Rivia",
                SchoolId = 3,
                School = null,
                Class = null,
                Course = null
            };
            
            _sut.Create(testTeacher);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var addedTeacher = _context.Teacher
                .FirstOrDefault(_ => _.Id == testTeacher.Id);
            
            addedTeacher.ShouldNotBeNull();
            addedTeacher.Firstname.ShouldBe(testTeacher.Firstname);
            addedTeacher.Lastname.ShouldBe(testTeacher.Lastname);
            addedTeacher.SchoolId.ShouldBe(testTeacher.SchoolId);
        }
        
        [Fact]
        public void should_update_teacher()
        {
            var testTeacher = new Teacher()
            {
                Id = 1,
                Firstname = "Pamela",
                Lastname = "Anderson",
                SchoolId = 2,
                School = null,
                Class = null,
                Course = null
            };

            var updatedTeacher =  _sut.Update(testTeacher);
            
            updatedTeacher.ShouldNotBeNull();
            updatedTeacher.Id.ShouldBe(testTeacher.Id);
            updatedTeacher.Firstname.ShouldBe(testTeacher.Firstname);
            updatedTeacher.Lastname.ShouldBe(testTeacher.Lastname);
            updatedTeacher.SchoolId.ShouldBe(testTeacher.SchoolId);
        }
    }
}