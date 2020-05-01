using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface IPupilInClassDal
    {
        int CreateClass(PupilInClass pupilInClassEntity);
        PupilInClass FindPupilInClassById(int id);
        ICollection<PupilInClass> FindAllPupilsInClass();
        void UpdatePupilInClass(PupilInClass pupilInClassEntity);
        void DeletePupilInClass(PupilInClass pupilInClassEntity);
    }
}