using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface ITeacherDal
    {
        int CreateTeacher(Teacher teacherEntity);
        Teacher FindTeacherById(int id);
        ICollection<Teacher> FindAllTeachers();
        void UpdateTeacher(Teacher teacherEntity);
        void DeleteTeacher(Teacher teacherEntity);
    }
}