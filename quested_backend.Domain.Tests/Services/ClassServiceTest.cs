using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class ClassServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly IClassService _sut;
        private readonly IClassMapper _classMapper;

        public ClassServiceTest(QuestedContextFactory questedContextFactory)
        {
            IClassRepository classRepository = 
                new ClassRepository(questedContextFactory.ContextInstance);
            ITeacherRepository teacherRepository = 
                new TeacherRepository(questedContextFactory.ContextInstance);
            _classMapper = questedContextFactory.ClassMapper;
            _sut = new ClassService(classRepository, teacherRepository ,_classMapper);
        }
        
        [Fact]
        public async Task getClasses_should_get_data()
        {
            var result = 
                await _sut.GetClassesAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getClass_should_get_data(int id)
        {
            var classRequest = new GetClassRequest { Id = id };
            
            var result =
                await _sut.ReadOnlyGetClassAsync(classRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("C1");
            //result.TaughtBy.Id.ShouldBe(1);
        }
        
        [Fact]
        public void getClass_with_null_should_throw_exception()
        {
            _sut
                .ReadOnlyGetClassAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        // [Theory]
        // [InlineData(-2)]
        // public void getClass_with_negative_id_should_throw_exception(int id)
        // {
        //     var classRequest = new GetClassRequest { Id = id };
        //
        //     _sut.
        //         ReadOnlyGetClassAsync(classRequest).
        //         ShouldThrow<ArgumentException>();
        // }
        //
        
        [Fact]
        public async Task addClass_should_add_correct_entity()
        {
        
            var _class = new AddClassRequest()
            {
                Name = "C5",
                TeacherId = 1
            };
        
            var addedClass =
                await _sut.AddClassAsync(_class);
            
            addedClass.ShouldNotBeNull();
            addedClass.Name.ShouldBe(_class.Name);
            // addedClass.TaughtBy.Id.ShouldBe(_class.TeacherId);
        }

        [Fact]
        public async Task editClass_should_correctly_edit_entity()
        {
            var _class = new EditClassRequest()
            {
                Id = 2,
                Name = "A3",
                TeacherId = 1,
            };

            var editedClass =
                await _sut.EditClassAsync(_class);
            
            editedClass.ShouldNotBeNull();
            editedClass.Id.ShouldBe(_class.Id);
            editedClass.Name.ShouldBe(_class.Name);
            editedClass.TaughtBy.ShouldNotBeNull();
            //editedClass.TaughtBy.Id.ShouldBe(_class.TeacherId);
        }
    }
}