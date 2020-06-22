using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class PupilServiceTests : IClassFixture<QuestedContextFactory>
    {
        private readonly EntityFrameworkRepository<Pupil, int> _pupilRepository;
        private readonly IPupilMapper _pupilMapper;

        public PupilServiceTests(QuestedContextFactory questedContextFactory)
        {
            _pupilRepository = new EntityFrameworkRepository<Pupil, int>(questedContextFactory.ContextInstance);
            _pupilMapper = questedContextFactory.PupilMapper;
        }

        [Fact]
        public async Task getItems_should_get_data()
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);

            var result = 
                await sut.GetPupilsAsync();

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(1)]
        public async Task getItem_should_get_data(int id)
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);
            var pupilRequest = new GetPupilRequest
            {
                Id = id
            };

            var result =
                await sut.GetPupilAsync(pupilRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Firstname.ShouldBe("Petr");
        }

        [Fact]
        public void getItem_with_null_should_throw_exception()
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);
            sut.GetPupilAsync(null).ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(-2)]
        public void getITem_with_negative_id_should_throw_exception(int id)
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);
            var pupilRequest = new GetPupilRequest
            {
                Id = id
            };

            sut.GetPupilAsync(pupilRequest).ShouldThrow<ArgumentException>();
        }

        [Fact]
        public async Task addItems_should_add_correct_entity()
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);

            var pupil = new AddPupilRequest
            {
                Firstname = "Marek"
            };

            var addedPupil =
                await sut.AddPupilAsync(pupil);
            
            addedPupil.ShouldNotBeNull();
            addedPupil.Firstname.ShouldBe("Marek");
        }

        [Fact]
        public async Task editItem_should_correctly_edit_entity()
        {
            var sut = new PupilService(_pupilRepository, _pupilMapper);

            var editPupil = new EditPupilRequest
            {
                Id = 3,
                Firstname = "Jan"
            };

            var editedPupil =
                await sut.EditPupilAsync(editPupil);
            
            editedPupil.ShouldNotBeNull();
            editedPupil.Id.ShouldBe(editPupil.Id);
            editedPupil.Firstname.ShouldBe(editedPupil.Firstname);
        }
    }
}