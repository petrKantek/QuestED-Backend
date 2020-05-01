using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface ICourseDal
    {
        int CreateCourse(Course courseEntity);
        Course FindCourseById(int id);
        ICollection<Course> FindAllCourses();
        void UpdateCourse(Course courseEntity);
        void DeleteCourse(Course courseEntity);
    }
}