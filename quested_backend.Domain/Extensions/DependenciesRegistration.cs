using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Extensions
{
    public static class DependenciesRegistration
    {
        /// <summary>
        /// Registers mappers into DI container
        /// </summary>
        /// <param name="services"></param>
        /// <returns> DI container </returns>
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<IPupilMapper, PupilMapper>()
                .AddSingleton<IClassMapper, ClassMapper>()
                .AddSingleton<ISchoolMapper, SchoolMapper>()
                .AddSingleton<ITeacherMapper, TeacherMapper>()
                .AddSingleton<ICourseMapper, CourseMapper>()
                .AddSingleton<IQuestionMapper, QuestionMapper>();

            return services;
        }
        
        /// <summary>
        /// Registers service classes into DI container
        /// </summary>
        /// <param name="services"></param>
        /// <returns> DI container ></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IPupilService, PupilService>()
                .AddScoped<ISchoolService, SchoolService>()
                .AddScoped<IClassService, ClassService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICourseService, CourseService>()
                .AddScoped<ITeacherService, TeacherService>();
            
            return services;
        }

        /// <summary>
        /// Registers fluent validators into DI container
        /// </summary>
        /// <param name="builder"></param>
        /// <returns> DI container </returns>
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