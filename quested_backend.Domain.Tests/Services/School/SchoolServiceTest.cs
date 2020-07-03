using System;
using System.Threading.Tasks;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services.School
{
    public class SchoolServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly ISchoolService _sut;

        public SchoolServiceTest(QuestedContextFactory questedContextFactory)
        {
            var context = questedContextFactory.ContextInstance;
            var schoolRepository = new SchoolRepository(context);
            var teacherRepository = new TeacherRepository(context);
            var schoolMapper = questedContextFactory.SchoolMapper;
            _sut = new SchoolService(schoolRepository, teacherRepository, schoolMapper);
        }
        
        [Fact]
        public async Task getSchools_should_get_data()
        {
            var result = 
                await _sut.GetSchoolsAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getSchool_should_get_data(int id)
        {
            var schoolRequest = new GetSchoolRequest { Id = id };
            
            var result =
                await _sut.ReadOnlyGetSchoolAsync(schoolRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("WU");
            result.Country.ShouldBe("Austria");
        }
        
        [Fact]
        public void getSchool_with_null_should_throw_exception()
        {
            _sut
                .ReadOnlyGetSchoolAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getSchool_with_negative_id_should_throw_exception(int id)
        {
            var schoolRequest = new GetSchoolRequest { Id = id };
        
            _sut.
                ReadOnlyGetSchoolAsync(schoolRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addSchool_should_add_correct_entity()
        {
            var school = new AddSchoolRequest
            {
                Name = "Angewandte",    
                Country = "Germany",
                SchoolOwnsSeasonIds = null,
                TeacherIds = null
            };
        
            var addedSchool =
                await _sut.AddSchoolAsync(school);
            
            addedSchool.ShouldNotBeNull();
            addedSchool.Name.ShouldBe(school.Name);
            addedSchool.Country.ShouldBe(school.Country);
        }

        [Fact]
        public async Task editSchool_should_correctly_edit_entity()
        {
            var school = new EditSchoolRequest()
            {
                Id = 3,
                Name = "JKU",
                Country = "Austria"
            };

            var editedSchool =
                await _sut.EditSchoolAsync(school);
            
            editedSchool.ShouldNotBeNull();
            editedSchool.Id.ShouldBe(school.Id);
            editedSchool.Name.ShouldBe(school.Name);
            editedSchool.Country.ShouldBe(school.Country);
        }
    }
}