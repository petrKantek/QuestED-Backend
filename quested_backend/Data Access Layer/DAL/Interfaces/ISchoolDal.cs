using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface ISchoolDal
    {
        int CreateSchool(School schoolEntity);
        School FindSchoolById(int id);
        ICollection<School> FindAllSchools();
        void UpdateSchool(School schoolEntity);
        void DeleteSchool(School schoolEntity);
    }
}