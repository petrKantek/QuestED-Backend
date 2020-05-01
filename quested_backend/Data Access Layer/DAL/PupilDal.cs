using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class PupilDal : IPupilDal
    {
        private QuestedContext questedContext;
        
        public int CreatePupil(Pupil pupilEntity)
        {
            var inserted = questedContext.Pupil.Add(pupilEntity).Entity;
            questedContext.SaveChanges();
            return inserted.Id;
        }

        public Pupil FindPupilById(int id)
        {
            return questedContext.Pupil.First(x => x.Id == id);
        }

        public ICollection<Pupil> FindAllPupils()
        {
            return questedContext.Pupil.ToList();
        }

        public void UpdatePupil([NotNull] Pupil pupilEntity)
        {
            questedContext.Pupil.Update(pupilEntity);
            questedContext.SaveChanges();
        }

        public void DeletePupil([NotNull] Pupil pupilEntity)
        {
            questedContext.Pupil.Remove(pupilEntity);
            questedContext.SaveChanges();
        }
    }
}