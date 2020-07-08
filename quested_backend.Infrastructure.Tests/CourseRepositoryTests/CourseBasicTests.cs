using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.CourseRepositoryTests
{
    public class CourseBasicTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly EntityFrameworkRepository<Course> _sut;

        public CourseBasicTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new EntityFrameworkRepository<Course>(_context);
        }
        
        [Fact]
        public async Task should_get_data()
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
            result.Name.ShouldBe("programming");
            result.TeacherId.ShouldBe(2);
            result.CourseId.ShouldBe(1);
        }
        
        [Fact]
        public async Task should_add_new_course()
        {
            var testCourse = new Course
            {
                Id = 4,
                Name = "C++",
                TeacherId = 2,
                CourseId = 1,
                CourseNavigation = null,
                Teacher = null,
                PupilInCourse = null
            };
            
            _sut.Create(testCourse);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var addedCourse = _context.Course
                .FirstOrDefault(_ => _.Id == testCourse.Id);
            
            addedCourse.ShouldNotBeNull();
            addedCourse.Id.ShouldBe(testCourse.Id);
            addedCourse.Name.ShouldBe(testCourse.Name);
            addedCourse.CourseId.ShouldBe(testCourse.CourseId);
            addedCourse.TeacherId.ShouldBe(testCourse.TeacherId);
        }
        
        [Fact]
        public void should_update_course()
        {
            var testCourse = new Course()
            {
                Id = 1,
                Name = "Statistics",
                TeacherId = 3,
                CourseId = 1,
                CourseNavigation = null,
                Teacher = null,
                PupilInCourse = null
            };

            var updatedCourse =  _sut.Update(testCourse);

            updatedCourse.ShouldNotBeNull();
            updatedCourse.Id.ShouldBe(testCourse.Id);
            updatedCourse.Name.ShouldBe(testCourse.Name);
            updatedCourse.TeacherId.ShouldBe(testCourse.TeacherId);
            updatedCourse.CourseId.ShouldBe(testCourse.CourseId);
        }
    }
}