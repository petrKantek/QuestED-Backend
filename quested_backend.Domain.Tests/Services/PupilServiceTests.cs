using System;
using System.Threading.Tasks;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class PupilServiceTests : IClassFixture<QuestedContextFactory>
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IPupilMapper _pupilMapper;
        private readonly IPupilService _sut;

        public PupilServiceTests(QuestedContextFactory questedContextFactory)
        {
            _pupilRepository = new PupilRepository(questedContextFactory.ContextInstance);
            _pupilMapper = questedContextFactory.PupilMapper;
            _sut = new PupilService(_pupilRepository, _pupilMapper);
        }

        [Fact]
        public async Task getPupils_should_get_data()
        {
            var result = await _sut.GetPupilsAsync();
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getPupil_should_get_data(int id)
        {
            var pupilRequest = new GetPupilRequest
            {
                Id = id
            };
        
            var result =
                await _sut.ReadOnlyGetPupilAsync(pupilRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Petr");
        }
        
        [Fact]
        public void getPupil_with_null_should_throw_exception()
        {
            _sut.ReadOnlyGetPupilAsync(null).ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task addPupil_should_add_correct_entity()
        {
            var pupil = new AddPupilRequest
            {
                Firstname = "Marek"
            };
        
            var addedPupil =
                await _sut.AddPupilAsync(pupil);
            
            addedPupil.ShouldNotBeNull();
            addedPupil.Firstname.ShouldBe("Marek");
        }

        [Fact]
        public async Task editPupil_should_correctly_edit_entity()
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);

            var editPupil = new EditPupilRequest
            {
                Id = 3,
                Firstname = "Jan"
            };

            var editedPupil = await sut.EditPupilAsync(editPupil);
            
            
            editedPupil.ShouldNotBeNull();
            editedPupil.Id.ShouldBe(editPupil.Id);
            editedPupil.Firstname.ShouldBe(editedPupil.Firstname);
        }
    }
}