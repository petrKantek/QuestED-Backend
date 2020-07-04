using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace quested_backend
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
            { }

        // protected override void AddTokenAuthentication(IServiceCollection services, IConfiguration configuration)
        // {
        //     // services.AddAuthentication( options =>
        //     // {
        //     //     options.DefaultAuthenticateScheme = "Test Scheme";
        //     //     options.DefaultChallengeScheme = "Test Scheme";
        //     // }).AddTestAuth(o => { });
        //     
        //     // services.AddAuthentication("Test")
        //     //     .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
        //     //         "Test", options => { });
        // }
    }
}