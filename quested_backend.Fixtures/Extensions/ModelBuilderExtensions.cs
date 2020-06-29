using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using quested_backend.Domain.Entities;

namespace quested_backend.Fixtures.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Reads data from given json file and seeds the database 
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="file"> file with json data </param>
        /// <typeparam name="T"> Entity whose data are contained in the file </typeparam>
        /// <returns> modelBuilder with seeded data from file </returns>
        public static ModelBuilder Seed<T>(this ModelBuilder modelBuilder, string file) where T : class
        {
            using (var reader = new StreamReader(file))
            {
                      var json = reader.ReadToEnd();
                      var data = JsonConvert.DeserializeObject<T[]>(json);
                      modelBuilder.Entity<T>().HasData(data);
            }
            return modelBuilder;
        }

        /// <summary>
        /// Seeds DB from all files in Data folder
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder SeedDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Seed<Pupil>("./Data/pupil.json")
                .Seed<Class>("./Data/class.json")
                .Seed<School>("./Data/school.json")
                .Seed<Teacher>("./Data/teacher.json")
                .Seed<Course>("./Data/course.json")
                .Seed<Season>("./Data/season.json")
                .Seed<Question>("./Data/question.json")
                .Seed<Episode>("./Data/episode.json")
                .Seed<SchoolOwnsSeason>("./Data/school_owns_season.json")
                .Seed<PupilInCourse>("./Data/pupil_in_course.json")
                .Seed<PupilInClass>("./Data/pupil_in_class.json")
                .Seed<PupilInCourseAnswersQuestion>("./Data/answered_questions.json");

            return modelBuilder;
        }
    }
}