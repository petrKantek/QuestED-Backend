using Microsoft.Extensions.DependencyInjection;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Infrastructure.Repositories;

namespace quested_backend.Infrastructure.Extensions
{
    public static class RepositoriesDependencyInjection
    {
        /// <summary>
        /// Registers repositories into Dependency Injection Container
        /// </summary>
        /// <param name="services"></param>
        /// <returns> services DI container </returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IPupilRepository, PupilRepository>()
                .AddScoped<ICourseRepository, CourseRepository>()
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddScoped<ISchoolRepository, SchoolRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<IRepository<Class>, EntityFrameworkRepository<Class>>()
                .AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}