using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class TeacherDal : ITeacherDal
    {
        private QuestedContext questedContext;
        
        public int CreateTeacher(Teacher teacherEntity)
        {
           var inserted = questedContext.Teacher.Add(teacherEntity).Entity;
           questedContext.SaveChanges();
           return inserted.Id;
        }

        public Teacher FindTeacherById(int id)
        {
            return questedContext.Teacher.First(x => x.Id == id);
        }

        public ICollection<Teacher> FindAllTeachers()
        {
            return questedContext.Teacher.ToList();
        }

      
        public void UpdateTeacher([NotNull] Teacher teacherEntity)
        {
            questedContext.Teacher.Update(teacherEntity);
            questedContext.SaveChanges();
        }

        public void DeleteTeacher([NotNull] Teacher teacherEntity)
        {
            questedContext.Teacher.Remove(teacherEntity);
            questedContext.SaveChanges();
        }
    }
}