using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests
{
    public class ClassControllerBasicTests : IClassFixture<InMemoryApplicationFactory<TestStartup>>
    {
        private readonly InMemoryApplicationFactory<TestStartup> _factory;

        public ClassControllerBasicTests(InMemoryApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/classes")]
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
            var response = await client.GetAsync($"/api/classes/2");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Class>(responseContent);

            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddClassRequest()
            {
                Name = "new class",
                TeacherId = 1
            };

            var client = _factory.CreateClient();

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/classes", httpsContent);

            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_existing_class()
        {
            var client = _factory.CreateClient();

            var request = new EditClassRequest()
            {
                Id = 1,
                Name = "edited class",
                TeacherId = 2
            };

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/classes", httpsContent);

            response.ShouldNotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Class>(responseContent);

            responseEntity.Name.ShouldBe(request.Name);
            responseEntity.Id.ShouldBe(request.Id);
          //  responseEntity.TeacherId.ShouldBe(request.TeacherId);
        }
    }
}