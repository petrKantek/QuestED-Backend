using System.Collections.Generic;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class PupilInCourseDal : IPupilInCourseDal
    {
        private QuestedContext questedContext;
        
        public int CreatePupilInCourse(PupilInCourse pupilInCourseEntity)
        {
            throw new System.NotImplementedException();
        }

        public PupilInCourse FindPupilInCourseById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<PupilInCourse> FindAllPupilsInCourse()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePupilInCourse(PupilInCourse pupilInCourseEntity)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePupilInCourse(PupilInCourse pupilInCourseEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}