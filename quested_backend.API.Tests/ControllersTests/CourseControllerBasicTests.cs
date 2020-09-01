using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests
{
    public class CourseControllerBasicTests : IClassFixture<InMemoryApplicationFactory<TestStartup>>
    {
        private readonly InMemoryApplicationFactory<TestStartup> _factory;

        public CourseControllerBasicTests(InMemoryApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/courses")]
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
            var response = await client.GetAsync($"/api/courses/2");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Course>(responseContent);

            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddCourseRequest()
            {
                Name = "new course",
                TeacherId = 1,
                SeasonId = 1
            };

            var client = _factory.CreateClient();

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/courses", httpsContent);

            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_existing_course()
        {
            var client = _factory.CreateClient();

            var request = new EditCourseRequest()
            {
                Id = 1,
                Name = "statistics",
                TeacherId = 1,
                SeasonId = 1
            };

            var httpsContent = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/courses", httpsContent);

            response.ShouldNotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Course>(responseContent);

            responseEntity.Name.ShouldBe("statistics");
            responseEntity.Id.ShouldBe(1);
//            responseEntity.TeacherId.ShouldBe(1);
        }
        
    }
}