using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Fixtures;
using quested_backend.Fixtures.Extensions;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests
{
    public class TeacherControllerBasicTests : IClassFixture<InMemoryApplicationFactory<TestStartup>>
    {
        private readonly InMemoryApplicationFactory<TestStartup> _factory;

        public TeacherControllerBasicTests(InMemoryApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/teachers")]
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
            var response = await client.GetAsync($"/api/teachers/2");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Teacher>(responseContent);

            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddTeacherRequest()
            {
                Firstname = "Sean",
                Lastname = "Diaz"
            };

            var client = _factory.CreateClient();

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/teachers", httpsContent);

            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_existing_teacher()
        {
            var client = _factory.CreateClient();

            var request = new EditTeacherRequest()
            {
                Id = 1,
                Firstname = "Daniel",
                Lastname = "Diaz",
                SchoolId = 1
            };

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/teachers", httpsContent);

            response.ShouldNotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Teacher>(responseContent);

            responseEntity.ShouldNotBeNull();
            responseEntity.Firstname.ShouldBe("Daniel");
            responseEntity.Id.ShouldBe(1);
            responseEntity.Lastname.ShouldBe("Diaz");
        }
    }
}