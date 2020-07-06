using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using quested_backend.Domain.Configurations;
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
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<QuestedContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"),
                        serverOptions =>
                        {
                            serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                        }))
                .AddOpenApiDocument(settings =>
                {
                    settings.Title = "Quested API";
                    settings.DocumentName = "v3";
                    settings.Version = "v3";
                })
                .AddRepositories()
                .AddMappers()
                .AddServices()
                .AddControllers()
                .AddValidation();

            AddTokenAuthentication(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
        }

        protected virtual void AddTokenAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("AuthenticationSettings");
            var settingsTyped = settings.Get<AuthenticationSettings>();

            services.Configure<AuthenticationSettings>(settings);
            var key = Encoding.ASCII.GetBytes(settingsTyped.Secret);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<QuestedContext>();
            
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}