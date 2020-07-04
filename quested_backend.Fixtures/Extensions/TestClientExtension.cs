using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace quested_backend.Fixtures.Extensions
{
    public static class TestClientExtension
    {
        public static WebApplicationFactory<T> WithAuthentication<T>(this WebApplicationFactory<T> factory) where T : class
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("Test", options => { });
                });
            });
        }
        
        public static HttpClient CreateClientWithTestAuth<T>(this WebApplicationFactory<T> factory) where T : class
        {
            // var client = factory.WithAuthentication().CreateClient(new WebApplicationFactoryClientOptions
            // {
            //     AllowAutoRedirect = false
            // });

            var client = factory.CreateClient();//new WebApplicationFactoryClientOptions
            // {
            //     AllowAutoRedirect = false
            // });
 
           // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
 
            return client;
        }
    }
}