using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Course;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class CourseServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly EntityFrameworkRepository<Course> _courseRepository;
        private readonly ICourseMapper _courseMapper;

        public CourseServiceTest(QuestedContextFactory questedContextFactory)
        {
            _courseRepository = new EntityFrameworkRepository<Course>(questedContextFactory.ContextInstance);
            _courseMapper = questedContextFactory.CourseMapper;
        }
        
        [Fact]
        public async Task getCourses_should_get_data()
        {
            var sut = new CourseService(_courseRepository, _courseMapper);
        
            var result = 
                await sut.GetCoursesAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getCourse_should_get_data(int id)
        {
            var sut = new CourseService(_courseRepository, _courseMapper);

            var courseRequest = new GetCourseRequest { Id = id };
            
            var result =
                await sut.ReadOnlyGetCourseAsync(courseRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("math");
            result.TeacherId.ShouldBe(3);
            result.SeasonId.ShouldBe(1);
        }
        
        [Fact]
        public void getCourse_with_null_should_throw_exception()
        {
            var sut = new CourseService(_courseRepository, _courseMapper);

            sut
                .ReadOnlyGetCourseAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getCourse_with_negative_id_should_throw_exception(int id)
        {
            var sut = new CourseService(_courseRepository, _courseMapper);
            var courseRequest = new GetCourseRequest() { Id = id };
        
            sut.
                ReadOnlyGetCourseAsync(courseRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addCourse_should_add_correct_entity()
        {
            var sut = new CourseService(_courseRepository, _courseMapper);
       
            var course = new AddCourseRequest()
            {
                Name = "software engineering",
                TeacherId = 2,
                SeasonId = 1
            };
        
            var addedCourse =
                await sut.AddCourseAsync(course);
            
            addedCourse.ShouldNotBeNull();
            addedCourse.Name.ShouldBe(course.Name);
            addedCourse.TeacherId.ShouldBe(course.TeacherId);
            addedCourse.SeasonId.ShouldBe(course.SeasonId);
        }

        [Fact]
        public async Task editCourse_should_correctly_edit_entity()
        {
            var sut = new CourseService(_courseRepository, _courseMapper);

            var editCourseRequest = new EditCourseRequest()
            {
                Id = 2,
                Name = "ASP NET Core",
                TeacherId = 3,
                SeasonId = 1
            };

            var editedCourse =
                await sut.EditCourseAsync(editCourseRequest);
            
            editedCourse.ShouldNotBeNull();
            editedCourse.Id.ShouldBe(editCourseRequest.Id);
            editedCourse.Name.ShouldBe(editCourseRequest.Name);
            editedCourse.SeasonId.ShouldBe(editCourseRequest.SeasonId);
            editedCourse.TeacherId.ShouldBe(editCourseRequest.TeacherId);
        }
    }
}