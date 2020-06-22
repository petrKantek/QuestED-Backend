using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Extensions;
using quested_backend.Domain.Repositories;
using quested_backend.Infrastructure;
using quested_backend.Infrastructure.Repositories;
using quested_backend.Infrastructure.Extensions;

namespace quested_backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services
                .AddDbContext<QuestedContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IRepository<Pupil, int>, EntityFrameworkRepository<Pupil, int>>()
                .AddScoped<IRepository<School, int>, EntityFrameworkRepository<School, int>>()
                .AddScoped<IRepository<Class, int>, EntityFrameworkRepository<Class, int>>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddTokenAuthentication(Configuration)
                .AddMappers()
                .AddServices()
                .AddControllers()
                .AddValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}