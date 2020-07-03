using System.Threading.Tasks;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services.School
{
    public class SchoolServiceRelationshipsTests : IClassFixture<QuestedContextFactory>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly ISchoolService _sut;

        public SchoolServiceRelationshipsTests(QuestedContextFactory questedContextFactory)
        {
            var context = questedContextFactory.ContextInstance;
            _schoolRepository = new SchoolRepository(context);
            _teacherRepository = new TeacherRepository(context);
            var schoolMapper = questedContextFactory.SchoolMapper;
            _sut = new SchoolService(_schoolRepository, _teacherRepository, schoolMapper);
        }

        [Fact]
        public async Task addTeacherToSchool_should_correctly_assign_teacher_to_school()
        {
            await _sut.AddTeacherToSchool(new AddTeacherToSchoolRequest
            {
                TeacherId = 4,
                SchoolId = 1
            });

            // var school = await _sut.GetSchoolAsync(new GetSchoolRequest{ Id = 1 });
            // school.ShouldNotBeNull();
            // school.

            var school = await _schoolRepository.GetByIdAsync(1);
            var teacher = await _teacherRepository.GetByIdAsync(4);
            
            school.ShouldNotBeNull();
            teacher.ShouldNotBeNull();
            school.Teacher.ShouldContain(teacher);
            teacher.School.ShouldBe(school);
        }

        // public async Task add_school_with_new_teacher_should_create_teacher()
        // {
        //     
        // }
    }
}