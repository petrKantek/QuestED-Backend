using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class CourseDal : ICourseDal
    {
        private QuestedContext questedContext;
        
        public int CreateCourse(Course courseEntity)
        {
            var inserted = questedContext.Course.Add(courseEntity).Entity;
            questedContext.SaveChanges();
            return inserted.Id;
        }

        public Course FindCourseById(int id)
        {
            return questedContext.Course.First(x => x.Id == id);
        }

        public ICollection<Course> FindAllCourses()
        {
            return questedContext.Course.ToList();
        }

        public void UpdateCourse([NotNull] Course courseEntity)
        {
            questedContext.Course.Update(courseEntity);
            questedContext.SaveChanges();
        }

        public void DeleteCourse([NotNull] Course courseEntity)
        {
            questedContext.Course.Remove(courseEntity);
            questedContext.SaveChanges();
        }
    }
}