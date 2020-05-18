using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using quested_backend.Domain.Mappers;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Services;

namespace quested_backend.Domain.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<IPupilMapper, PupilMapper>()
                .AddSingleton<IClassMapper, ClassMapper>()
                .AddSingleton<ISchoolMapper, SchoolMapper>()
                .AddSingleton<ITeacherMapper, TeacherMapper>();

            return services;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IPupilService, PupilService>();
            
            return services;
        }

        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(configuration => 
                    configuration.RegisterValidatorsFromAssembly
                        (Assembly.GetExecutingAssembly()));
            
            return builder; 
        }
    }
}