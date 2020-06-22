using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using quested_backend.Infrastructure;

namespace quested_backend.Fixtures
{
    public class InMemoryApplicationFactory<TStartup> :
        WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    var options = new DbContextOptionsBuilder<QuestedContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options;

                    services.AddScoped<QuestedContext>(serviceProvider =>
                        new TestQuestedContext(options));
                    
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