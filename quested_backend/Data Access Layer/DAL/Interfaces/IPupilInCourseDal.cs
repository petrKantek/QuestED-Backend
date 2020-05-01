using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface IPupilInCourseDal
    {
        int CreatePupilInCourse(PupilInCourse pupilInCourseEntity);
        PupilInCourse FindPupilInCourseById(int id);
        ICollection<PupilInCourse> FindAllPupilsInCourse();
        void UpdatePupilInCourse(PupilInCourse pupilInCourseEntity);
        void DeletePupilInCourse(PupilInCourse pupilInCourseEntity); 
    }
}