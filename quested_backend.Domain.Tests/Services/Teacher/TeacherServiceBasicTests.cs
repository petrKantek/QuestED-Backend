using System;
using System.Threading.Tasks;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services.Teacher
{
    public class TeacherServiceTests : IClassFixture<QuestedContextFactory>
    {
        private readonly ITeacherService _sut;

        public TeacherServiceTests(QuestedContextFactory questedContextFactory)
        {
            var teacherRepository = new TeacherRepository(questedContextFactory.ContextInstance);
            var courseRepository = new PupilRepository(questedContextFactory.ContextInstance);
            var questionRepository = new QuestionRepository(questedContextFactory.ContextInstance);
            var teacherMapper = questedContextFactory.TeacherMapper;
            _sut = new TeacherService(teacherRepository, courseRepository, questionRepository, teacherMapper);
        }
        
        [Fact]
        public async Task getTeachers_should_get_data()
        {
            var result = 
                await _sut.GetTeachersAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getTeacher_should_get_data(int id)
        {
            var teacherRequest = new GetTeacherRequest { Id = id };
            
            var result =
                await _sut.ReadOnlyGetTeacherAsync(teacherRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Jim");
            result.Lastname.ShouldBe("Rogers");
            result.SchoolId.ShouldBe(1);
        }
        
        [Fact]
        public void getTeacher_with_null_should_throw_exception()
        {
            _sut
                .ReadOnlyGetTeacherAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getTeacher_with_negative_id_should_throw_exception(int id)
        {
            var teacherRequest = new GetTeacherRequest { Id = id };
        
            _sut.
                ReadOnlyGetTeacherAsync(teacherRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addTeacher_should_add_correct_entity()
        {
            var teacher = new AddTeacherRequest
            {
                Firstname = "Marek"
            };
        
            var addedTeacher =
                await _sut.AddTeacherAsync(teacher);
            
            addedTeacher.ShouldNotBeNull();
            addedTeacher.Firstname.ShouldBe("Marek");
        }

        [Fact]
        public async Task editTeacher_should_correctly_edit_entity()
        {
            var teacher = new EditTeacherRequest()
            {
                Id = 3,
                Firstname = "Jan",
                Lastname = "Parson",
                ClassIds = null,
                CourseIds = null,
                SchoolId = 1
            };

            var editedTeacher =
                await _sut.EditTeacherAsync(teacher);
            
            editedTeacher.ShouldNotBeNull();
            editedTeacher.Id.ShouldBe(teacher.Id);
            editedTeacher.Firstname.ShouldBe(teacher.Firstname);
        }
    }
}