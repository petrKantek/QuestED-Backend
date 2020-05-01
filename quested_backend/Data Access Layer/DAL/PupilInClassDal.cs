using System.Collections.Generic;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class PupilInClassDal : IPupilInClassDal
    {
        private QuestedContext questedContext;
        
        public int CreateClass(PupilInClass pupilInClassEntity)
        {
            throw new System.NotImplementedException();
        }

        public PupilInClass FindPupilInClassById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<PupilInClass> FindAllPupilsInClass()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePupilInClass(PupilInClass pupilInClassEntity)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePupilInClass(PupilInClass pupilInClassEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}