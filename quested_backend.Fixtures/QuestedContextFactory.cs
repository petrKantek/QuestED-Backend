﻿using System;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Mappers;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Infrastructure;

namespace quested_backend.Fixtures
{
    public class QuestedContextFactory
    {
        public readonly TestQuestedContext ContextInstance;
        public readonly IPupilMapper PupilMapper;
        public readonly ISchoolMapper SchoolMapper;
        public readonly ITeacherMapper TeacherMapper;
        public readonly IClassMapper ClassMapper;
        public readonly ICourseMapper CourseMapper;

        /// <summary>
        /// Produces TestQuestedContexts
        /// </summary>
        public QuestedContextFactory()
        {
            var contextOptions = new DbContextOptionsBuilder<QuestedContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            EnsureCreation(contextOptions);
            ContextInstance = new TestQuestedContext(contextOptions);
            PupilMapper = new PupilMapper();
            SchoolMapper = new SchoolMapper();
            TeacherMapper = new TeacherMapper(SchoolMapper);
            ClassMapper = new ClassMapper(TeacherMapper);
            CourseMapper = new CourseMapper(); //TODO Properly define course mapper
        }
        
        private void EnsureCreation(DbContextOptions<QuestedContext> contextOptions) 
        {  
            using var context = new TestQuestedContext(contextOptions);
            context.Database.EnsureCreated();
        } 
    }
}