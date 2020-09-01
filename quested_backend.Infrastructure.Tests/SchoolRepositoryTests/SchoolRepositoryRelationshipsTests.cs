using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.SchoolRepositoryTests
{
    public class SchoolRepositoryRelationshipsTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly ISchoolRepository _sut;
        private readonly ITeacherRepository _teacherRepository;

        public SchoolRepositoryRelationshipsTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _sut = new SchoolRepository(_context);
            _teacherRepository = new TeacherRepository(_context);
        }

        [Fact]
        public async Task creating_school_with_new_teacher_should_propagate_the_teacher_to_db()
        {
            var school = new School
            {
                Name = "VUT",
                Country = "CZE",
                SchoolOwnsSeason = null,
                Teacher = new List<Teacher>
                {
                    new Teacher
                    {
                        Firstname = "Tomas",
                        Lastname = "Sobek",
                    }
                }
            };

            var addedSchool = _sut.Create(school);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var testSchool = await _context.Set<School>()
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(x => x.Id == addedSchool.Id);
            
            testSchool.ShouldNotBeNull();
            testSchool.Country.ShouldBe(addedSchool.Country);
            testSchool.Name.ShouldBe(addedSchool.Name);
            testSchool.Id.ShouldBe(addedSchool.Id);
            testSchool.Teacher.ShouldBe(addedSchool.Teacher);

            var testTeacher = await _context.Set<Teacher>()
                .Include(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == addedSchool.Teacher.First().Id);
            
            testTeacher.ShouldNotBeNull();
            testTeacher.Firstname.ShouldBe(testSchool.Teacher.First().Firstname);
            testTeacher.Lastname.ShouldBe(testSchool.Teacher.First().Lastname);
            testTeacher.School.ShouldBe(testSchool);
        }

        [Fact]
        public async Task creating_school_with_already_existing_teacher_should_propagate_school_to_teacher()
        {
            var teacher = new Teacher
            {
                Firstname = "Tomas",
                Lastname = "Sobek",
            };

            var addedTeacher =  _teacherRepository.Create(teacher);
            await _teacherRepository.UnitOfWork.SaveEntitiesAsync();
            
            addedTeacher.ShouldNotBeNull();
            addedTeacher.School.ShouldBeNull();

            var school = new School
            {
                Name = "VUT",
                Country = "CZE",
                SchoolOwnsSeason = null,
                Teacher = new List<Teacher>
                {
                    addedTeacher
                }
            };

            var addedSchool = _sut.Create(school);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            var testSchool = await _context.Set<School>()
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(x => x.Id == addedSchool.Id);
            
            testSchool.ShouldNotBeNull();
            testSchool.Country.ShouldBe(addedSchool.Country);
            testSchool.Name.ShouldBe(addedSchool.Name);
            testSchool.Id.ShouldBe(addedSchool.Id);
            testSchool.Teacher.ShouldBe(addedSchool.Teacher);

            var testTeacher = await _context.Set<Teacher>()
                .Include(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == addedSchool.Teacher.First().Id);
            
            testTeacher.ShouldNotBeNull();
            testTeacher.Firstname.ShouldBe(testSchool.Teacher.First().Firstname);
            testTeacher.Lastname.ShouldBe(testSchool.Teacher.First().Lastname);
            testTeacher.School.ShouldBe(testSchool);
        }
    }
}