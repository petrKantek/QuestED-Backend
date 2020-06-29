using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace quested_backend.Infrastructure.Tests.PupilRepositoryTests
{
    public class PupilRepositoryRelationshipsTests : IClassFixture<QuestedContextFactory>
    {
        private readonly PupilRepository _pupilRep;
        private readonly EntityFrameworkRepository<Class> _classRep;
        private readonly TestQuestedContext _context;
        
        public PupilRepositoryRelationshipsTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            _pupilRep = new PupilRepository(_context);
            _classRep = new EntityFrameworkRepository<Class>(_context);
        }

        [Fact]
        public async Task should_add_pupil_to_class()
        {
            // var _class = _context.Class.Include(x => x.PupilInClass)
            //     .Single(y => y.Id == 2);

            var _class = await _classRep.GetByIdAsync(3);
            var _pupil = await _pupilRep.GetByIdAsync(1);

            _class.ShouldNotBeNull();
            _pupil.ShouldNotBeNull();
            
            _class.PupilInClass.Add(new PupilInClass
            {
                Pupil = _pupil,
                Class = _class
            });
            
            await _classRep.UnitOfWork.SaveEntitiesAsync();

            var addedPupil = _context.Class.FirstOrDefault(x =>
                x.Id == 3)
                ?.PupilInClass.FirstOrDefault(y => 
                    y.Pupil == _pupil);
            
            addedPupil.ShouldNotBeNull();
            addedPupil.Class.ShouldBe(_class);
            addedPupil.Pupil.ShouldBe(_pupil);
            
            var addedClass = _context.Pupil.FirstOrDefault(x =>
                    x.Id == 1)
                ?.PupilInClass.FirstOrDefault(y => 
                    y.Class == _class );

            addedClass.ShouldNotBeNull();
            addedClass.Class.ShouldBe(_class);
            addedClass.Pupil.ShouldBe(_pupil);
        } 
    }
}