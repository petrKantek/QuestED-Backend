using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class TeacherServiceTests : IClassFixture<QuestedContextFactory>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IPupilRepository _courseRepository;
        private readonly ITeacherMapper _teacherMapper;

        public TeacherServiceTests(QuestedContextFactory questedContextFactory)
        {
            _teacherRepository = new TeacherRepository(
                questedContextFactory.ContextInstance);
            _courseRepository = new PupilRepository(
                questedContextFactory.ContextInstance);
            _teacherMapper = questedContextFactory.TeacherMapper;
        }
        
        [Fact]
        public async Task getTeachers_should_get_data()
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);
        
            var result = 
                await sut.GetTeachersAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getTeacher_should_get_data(int id)
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);
            var teacherRequest = new GetTeacherRequest { Id = id };
            
            var result =
                await sut.ReadOnlyGetTeacherAsync(teacherRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Jim");
            result.Lastname.ShouldBe("Rogers");
            result.SchoolId.ShouldBe(1);
        }
        
        [Fact]
        public void getTeacher_with_null_should_throw_exception()
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);
            sut
                .ReadOnlyGetTeacherAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getTeacher_with_negative_id_should_throw_exception(int id)
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);
            var teacherRequest = new GetTeacherRequest { Id = id };
        
            sut.
                ReadOnlyGetTeacherAsync(teacherRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addTeacher_should_add_correct_entity()
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);
        
            var teacher = new AddTeacherRequest
            {
                Firstname = "Marek"
            };
        
            var addedTeacher =
                await sut.AddTeacherAsync(teacher);
            
            addedTeacher.ShouldNotBeNull();
            addedTeacher.Firstname.ShouldBe("Marek");
        }

        [Fact]
        public async Task editTeacher_should_correctly_edit_entity()
        {
            var sut = new TeacherService(_teacherRepository, _courseRepository, _teacherMapper);

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
                await sut.EditTeacherAsync(teacher);
            
            editedTeacher.ShouldNotBeNull();
            editedTeacher.Id.ShouldBe(teacher.Id);
            editedTeacher.Firstname.ShouldBe(teacher.Firstname);
        }
    }
}