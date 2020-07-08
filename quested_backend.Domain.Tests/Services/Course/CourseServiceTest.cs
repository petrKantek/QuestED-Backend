using System;
using System.Threading.Tasks;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services.Course
{
    public class CourseServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseMapper _courseMapper;

        public CourseServiceTest(QuestedContextFactory questedContextFactory)
        {
            _courseRepository = new CourseRepository(questedContextFactory.ContextInstance);
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
//            result.TaughtBy.Id.ShouldBe(3);
 //           result.TaughtInSeason.ShouldBe("Spring Summer 2020");
        }
        
        [Fact]
        public void getCourse_with_null_should_throw_exception()
        {
            var sut = new CourseService(_courseRepository, _courseMapper);

            sut
                .ReadOnlyGetCourseAsync(null).
                ShouldThrow<ArgumentNullException>();
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
//            addedCourse.TaughtBy.Id.ShouldBe(course.TeacherId);
//            addedCourse.TaughtInSeason.ShouldBe("Spring Summer 2020");
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
//            editedCourse.TaughtInSeason.ShouldBe("Spring Summer 2020");
 //           editedCourse.TaughtBy.Id.ShouldBe(editCourseRequest.TeacherId);
        }
    }
}