using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using quested_backend.Infrastructure;

namespace quested_backend.Fixtures
{
    public class InMemoryApplicationFactory<TStartup> :
        WebApplicationFactory<TStartup> where TStartup : class
    {
        // protected override IWebHostBuilder CreateWebHostBuilder()
        // {
        //     var builder = new WebHostBuilder().UseStartup<TStartup>().UseTestServer()
        //         .ConfigureAppConfiguration((hostingContext, config) =>
        //         {
        //             config.AddJsonFile("/home/petr/QuestED-Backend/quested_backend.API/appsettings.json", optional: false, reloadOnChange: false);
        //         });
        //     return builder;
        // }

        /// <summary>
        /// Configures an http client running in separate process
        /// used for testing controllers
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    var dbOptions = new DbContextOptionsBuilder<QuestedContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options;

                    if (typeof(TStartup).IsSubclassOf(typeof(Startup)))
                    {
                        services.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = "Test";
                            options.DefaultChallengeScheme = "Test";
                        }).AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                            "Test", options => { });
                    }

                    services.AddScoped<QuestedContext>(serviceProvider =>
                        new TestQuestedContext(dbOptions));
                    
                    services.Replace(ServiceDescriptor.Scoped(_ =>
                        new UsersContextFactory().InMemoryUserManager)); //TODO not sure if correct
                    
                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<QuestedContext>();
                    db.Database.EnsureCreated();
                });
        }
    }
}