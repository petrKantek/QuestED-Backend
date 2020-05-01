using System.Collections;
using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface IClassDal
    {
        int CreateClass(Class classEntity);
        Class FindClassById(int id);
        ICollection<Class> FindAllClasses();
        void UpdateClass(Class classEntity);
        void DeleteClass(Class classEntity);
    }
}