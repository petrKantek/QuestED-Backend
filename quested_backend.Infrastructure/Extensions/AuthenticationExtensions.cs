﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using quested_backend.Domain.Configurations;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Services;

namespace quested_backend.Infrastructure.Extensions
{
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Registers authentication service to the DI container
        /// </summary>
        /// <param name="services">collection of injected service classes</param>
        /// <param name="configuration">quested_backend/API/appsettings.json file</param>
        /// <returns>DI Container</returns>
        public static IServiceCollection AddTokenAuthentication(
            this IServiceCollection services, IConfiguration configuration)
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
            return services;
        }
    }
}