using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class ClassDal : IClassDal
    {
        private QuestedContext questedContext;
        
        public int CreateClass(Class classEntity)
        {
            var inserted = questedContext.Class.Add(classEntity).Entity;
            questedContext.SaveChanges();
            return inserted.Id;
        }

        public Class FindClassById(int id)
        {
            return questedContext.Class.First(x => x.Id == id);
        }

        public ICollection<Class> FindAllClasses()
        {
            return questedContext.Class.ToList();
        }

        public void UpdateClass([NotNull] Class classEntity)
        {
            questedContext.Class.Update(classEntity);
            questedContext.SaveChanges();
        }

        public void DeleteClass([NotNull] Class classEntity)
        {
            questedContext.Class.Remove(classEntity);
            questedContext.SaveChanges();
        }
    }
}