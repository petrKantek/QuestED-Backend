using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface IPupilDal
    {
        int CreatePupil(Pupil pupilEntity);
        Pupil FindPupilById(int id);
        ICollection<Pupil> FindAllPupils();
        void UpdatePupil(Pupil pupilEntity);
        void DeletePupil(Pupil pupilEntity);
    }
}