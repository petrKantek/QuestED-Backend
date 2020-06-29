using System;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Services;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class ClassServiceTest : IClassFixture<QuestedContextFactory>
    {
        private readonly EntityFrameworkRepository<Class> _classRepository;
        private readonly IClassMapper _classMapper;

        public ClassServiceTest(QuestedContextFactory questedContextFactory)
        {
            _classRepository = new EntityFrameworkRepository<Class>(questedContextFactory.ContextInstance);
            _classMapper = questedContextFactory.ClassMapper;
        }
        
        [Fact]
        public async Task getClasses_should_get_data()
        {
            var sut = new ClassService(_classRepository, _classMapper);
        
            var result = 
                await sut.GetClassesAsync();
        
            result.ShouldNotBeNull();
        }
        
        [Theory]
        [InlineData(1)]
        public async Task getClass_should_get_data(int id)
        {
            var sut = new ClassService(_classRepository, _classMapper);
            var classRequest = new GetClassRequest { Id = id };
            
            var result =
                await sut.ReadOnlyGetClassAsync(classRequest);
            
            result.ShouldNotBeNull();
            result.Id.ShouldBe(id);
            result.Name.ShouldBe("C1");
            result.TeacherId.ShouldBe(1);
        }
        
        [Fact]
        public void getClass_with_null_should_throw_exception()
        {
            var sut = new ClassService(_classRepository, _classMapper);
            sut
                .ReadOnlyGetClassAsync(null).
                ShouldThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(-2)]
        public void getClass_with_negative_id_should_throw_exception(int id)
        {
            var sut = new ClassService(_classRepository, _classMapper);
            var classRequest = new GetClassRequest { Id = id };
        
            sut.
                ReadOnlyGetClassAsync(classRequest).
                ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public async Task addClass_should_add_correct_entity()
        {
            var sut = new ClassService(_classRepository, _classMapper);
        
            var _class = new AddClassRequest()
            {
                Name = "C5",
                TeacherId = 1
            };
        
            var addedClass =
                await sut.AddClassAsync(_class);
            
            addedClass.ShouldNotBeNull();
            addedClass.Name.ShouldBe(_class.Name);
            addedClass.TeacherId.ShouldBe(_class.TeacherId);
        }

        [Fact]
        public async Task editClass_should_correctly_edit_entity()
        {
            var sut = new ClassService(_classRepository, _classMapper);


            var _class = new EditClassRequest()
            {
                Id = 2,
                Name = "A3",
                TeacherId = 1,
            };

            var editedClass =
                await sut.EditClassAsync(_class);
            
            editedClass.ShouldNotBeNull();
            editedClass.Id.ShouldBe(_class.Id);
            editedClass.Name.ShouldBe(_class.Name);
            editedClass.TeacherId.ShouldBe(_class.TeacherId);
        }
    }
}