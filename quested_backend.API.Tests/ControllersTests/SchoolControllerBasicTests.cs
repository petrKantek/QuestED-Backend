using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests
{
    public class SchoolControllerBasicTests : IClassFixture<InMemoryApplicationFactory<TestStartup>>
    {
        private readonly InMemoryApplicationFactory<TestStartup> _factory;

        public SchoolControllerBasicTests(InMemoryApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/schools")]
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
            var response = await client.GetAsync($"/api/schools/2");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<School>(responseContent);

            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddSchoolRequest()
            {
                Name = "new school",
                Country = "CZE"
            };

            var client = _factory.CreateClient();

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/schools", httpsContent);

            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_existing_school()
        {
            var client = _factory.CreateClient();

            var request = new EditSchoolRequest()
            {
                Id = 1,
                Name = "JKU",
                Country = "Germany"
            };

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/schools", httpsContent);

            response.ShouldNotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<School>(responseContent);

            responseEntity.Name.ShouldBe("JKU");
            responseEntity.Id.ShouldBe(1);
            responseEntity.Country.ShouldBe("Germany");
        }
    }
}