using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests
{
    public class PupilControllerBasicTests : IClassFixture<InMemoryApplicationFactory<TestStartup>>
    {
        private readonly InMemoryApplicationFactory<TestStartup> _factory;

        public PupilControllerBasicTests(InMemoryApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/pupils")]
        public async Task get_should_return_success(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task get_by_id_should_return_item_data()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"/api/pupils/2");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Pupil>(responseContent);

            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddPupilRequest
            {
                Firstname = "Miroslav",
                PupilInClassIds = null,
                PupilInCourseIds = null
            };

            var client = _factory.CreateClient();

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/pupils", httpsContent);

            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_exisitng_pupil()
        {
            var client = _factory.CreateClient();

            var request = new EditPupilRequest
            {
                Id = 2,
                Firstname = "Jirka",
                PupilInClassIds = null,
                PupilInCourseIds = null
            };

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/pupils/{request.Id}", httpsContent);

            response.ShouldNotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Pupil>(responseContent);

            responseEntity.Firstname.ShouldBe("Jirka");
        }
    }
}
