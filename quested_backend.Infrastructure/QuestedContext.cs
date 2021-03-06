﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Infrastructure.SchemaDefinitions;

namespace quested_backend.Infrastructure
{
    /// <summary>
    /// The main entry point of Entity Framework Core
    /// </summary>
    public class QuestedContext : IdentityDbContext<User>, IUnitOfWork
    {
        public QuestedContext(DbContextOptions<QuestedContext> options)
            : base(options) {}

        /// <summary>
        /// Collections of entities. Virtual modifier is used to enable lazy loading
        /// </summary>
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
        public virtual DbSet<Pupil> Pupil { get; set; }
        public virtual DbSet<PupilInClass> PupilInClass { get; set; }
        public virtual DbSet<PupilInCourse> PupilInCourse { get; set; }
        public virtual DbSet<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        
        /// <summary>
        /// Unit Of Work pattern implementation
        /// </summary>
        /// <param name="cancellationToken">token propagating information whether save entities
        /// task should be cancelled</param>
        /// <returns>true if saving entities to database was successful</returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true; 
        }
        
        /// <summary>
        /// Models the relations and their relationships in the database.
        /// Executes extension methods that use Fluent API.
        /// </summary>
        /// <param name="modelBuilder">object configuring database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new CourseEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new EpisodeEntitySchemaDefinition());
            
            modelBuilder.ApplyConfiguration(new PupilEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new PupilInClassEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new PupilInCourseAnswersQuestionEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new PupilInCourseEntitySchemaDefinition());

            modelBuilder.ApplyConfiguration(new QuestionEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new SchoolEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new SchoolOwnsSeasonEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new SeasonEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new TeacherEntitySchemaDefinition());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
