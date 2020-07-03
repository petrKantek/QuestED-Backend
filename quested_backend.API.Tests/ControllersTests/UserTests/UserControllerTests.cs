using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quested_backend.Domain.Requests.User;
using quested_backend.Domain.Responses;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace quested_backend.API.Tests.ControllersTests.UserTests
{
    /// <summary>
    /// Tests correct sign-in, sign-up process on the User Controller
    /// </summary>
    public class UserControllerTests :
        IClassFixture<InMemoryApplicationFactory<Startup>>
    {
        private readonly InMemoryApplicationFactory<Startup> _factory;

        public UserControllerTests(InMemoryApplicationFactory<Startup> factory)
        { 
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/user/auth")]
        public async Task sign_in_should_retrieve_a_token(string url)
        {
            var client = _factory.CreateClient();
            var request = new SignInRequest
            {
                Email = "test_email@email.com",
                Password =  "quested",
                Role = "Admin"
            };
            
            var httpContent = new StringContent(
                JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseContent.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData("/api/user/auth")]
        public async Task sign_in_should_retrieve_bad_request_with_invalid_password(string url)
        {
            var client = _factory.CreateClient();
            var request = new SignInRequest
            {
                Email = "test_email@email.com",
                Password =  "invalid_passwd",
                Role = "Admin"
            };
            
            var httpContent = new StringContent(
                JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            responseContent.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData("/api/user")]
        public async Task get_with_authorized_user_should_retrieve_the_right_user(string url)
        {
            var client = _factory.CreateClient();
            var signInRequest = new SignInRequest
            {
                Email = "test_email@email.com",
                Password =  "quested",
                Role = "Admin"
            };
            var httpContent = new StringContent(
                JsonConvert.SerializeObject(signInRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{url}/auth", httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", tokenResponse.Token);

            var restrictedResponse = await client.GetAsync(url);

            restrictedResponse.EnsureSuccessStatusCode();
            restrictedResponse.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        
        [Theory]
        [InlineData("/api/user")]
        public async Task post_should_create_a_new_user(string url)
        {
            var client = _factory.CreateClient();

            var signUpRequest = new SignUpRequest()
                { Email = "samuele.resca@example.com", Password = "P@$$w0rd", Name = "Samuele", Role = "Teacher"};
            var httpContent =
                new StringContent(JsonConvert.SerializeObject(signUpRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);
            var test = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBe("http://localhost/api/user");
        }
    }
}