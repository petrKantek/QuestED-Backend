using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class SchoolDal : ISchoolDal
    {
        private QuestedContext questedContext;
        
        public int CreateSchool(School schoolEntity)
        {
            var inserted = questedContext.School.Add(schoolEntity).Entity;
            questedContext.SaveChanges();
            return inserted.Id;
        }

        public School FindSchoolById(int id)
        {
            return questedContext.School.First(x => x.Id == id);
        }

        public ICollection<School> FindAllSchools()
        {
            return questedContext.School.ToList();
        }

        public void UpdateSchool([NotNull] School schoolEntity)
        {
            questedContext.School.Update(schoolEntity);
            questedContext.SaveChanges();
        }

        public void DeleteSchool([NotNull] School schoolEntity)
        {
            questedContext.School.Remove(schoolEntity);
            questedContext.SaveChanges();
        }
    }
}