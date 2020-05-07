using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using quested_backend.Domain.Repositories;
using quested_backend.Entities;
using quested_backend.Infrastructure;
using quested_backend.Infrastructure.Repositories;

namespace DalTests
{
    
    public class Tests
    {
        
        private Mock<DbSet<Pupil>> _pupilDbSet;
        private Mock<QuestedContext> _questedContext;

        private IPupilDal _pupilDal;
        // private DbSet<Pupil> _dbSet;

        [SetUp]
        public void Setup()
        {
          //   _questedContext = new Mock<QuestedContext>();
          // //  _pupilDbSet = new Mock<DbSet<Pupil>>();
          //   
          //  
          // //  _questedContext.Setup(m => m.Pupil.First(x => x.Id == ))
          //   
          //   _pupilDal = new PupilDal(_questedContext.Object);
            
        }

        [Test]
        public void Test()
        {
            
            _questedContext = new Mock<QuestedContext>();
            _pupilDbSet = new Mock<DbSet<Pupil>>();
            

            _pupilDal = new PupilDal(_questedContext.Object);
            
            var pupil1 = new Pupil {Id = 2, Firstname = "Petr"};

            _questedContext.Setup(q => q.Pupil).Returns(_pupilDbSet.Object);
            _pupilDbSet.Setup(d => d.Add(pupil1)).Returns(pupil1.);

            Pupil insertedPupil1 =_pupilDal.CreatePupil(pupil1);
            
           _questedContext.Verify(m => m.Pupil.Add(pupil1),Times.Once() );
            _questedContext.Verify(m => m.SaveChanges(), Times.Once());
            
        }
    }
}