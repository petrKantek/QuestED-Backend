using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class SchoolServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly EntityFrameworkRepository<School> _schoolRepository;
        private readonly ISchoolMapper _schoolMapper;

        public SchoolServiceTest(QuestedContextFactory questedContextFactory)
        {
            _schoolRepository = new EntityFrameworkRepository<School>(questedContextFactory.ContextInstance);
            _schoolMapper = questedContextFactory.SchoolMapper;
        }
        
        [Fact]
        public async Task getSchools_should_get_data()
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);
        
            var result = 
                await sut.GetSchoolsAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getSchool_should_get_data(int id)
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);
            var schoolRequest = new GetSchoolRequest { Id = id };
            
            var result =
                await sut.ReadOnlyGetSchoolAsync(schoolRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("WU");
            result.Country.ShouldBe("Austria");
        }
        
        [Fact]
        public void getSchool_with_null_should_throw_exception()
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);
            sut
                .ReadOnlyGetSchoolAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getSchool_with_negative_id_should_throw_exception(int id)
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);
            var schoolRequest = new GetSchoolRequest { Id = id };
        
            sut.
                ReadOnlyGetSchoolAsync(schoolRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addSchool_should_add_correct_entity()
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);
        
            var school = new AddSchoolRequest
            {
                Name = "Angewandte",    
                Country = "Germany",
                SchoolOwnsSeasonIds = null,
                TeacherIds = null
            };
        
            var addedSchool =
                await sut.AddSchoolAsync(school);
            
            addedSchool.ShouldNotBeNull();
            addedSchool.Name.ShouldBe(school.Name);
            addedSchool.Country.ShouldBe(school.Country);
        }

        [Fact]
        public async Task editSchool_should_correctly_edit_entity()
        {
            var sut = new SchoolService(_schoolRepository, _schoolMapper);

            var school = new EditSchoolRequest()
            {
                Id = 3,
                Name = "JKU",
                Country = "Austria"
            };

            var editedSchool =
                await sut.EditSchoolAsync(school);
            
            editedSchool.ShouldNotBeNull();
            editedSchool.Id.ShouldBe(school.Id);
            editedSchool.Name.ShouldBe(school.Name);
            editedSchool.Country.ShouldBe(school.Country);
        }
    }
}