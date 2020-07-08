using quested_backend.Domain.Entities;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers
{
    /// <summary>
    /// Methods of these classes map entities to basic info responses(so only attributes that are
    /// not of entity type)
    /// </summary>
    public static class HelperMapper
    {
        public static AnswerBasicInfo BasicMap(PupilInCourseAnswersQuestion answer)
        {
            return new AnswerBasicInfo
            {
                AchievedPoints = answer.AchievedPoints,
                AnsweredBy = BasicMap(answer.PupilInCourse.Pupil)
            };
        }

        public static ClassBasicInfo BasicMap(Class _class)
        {
            return new ClassBasicInfo
            {
                Id = _class?.Id,
                Name = _class?.Name
            };
        }

        public static CourseBasicInfo BasicMap(Course course)
        {
            return new CourseBasicInfo
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public static SchoolBasicInfo BasicMap(School school)
        {
            return new SchoolBasicInfo
            {
                Id = school?.Id,
                Name = school?.Name,
                Country = school?.Country
            };
        }

        public static TeacherBasicInfo BasicMap(Teacher teacher)
        {
            return new TeacherBasicInfo
            {
                Id = teacher?.Id,
                Firstname = teacher?.Firstname,
                Lastname = teacher?.Lastname
            };
        }

        public static PupilBasicInfo BasicMap(Pupil pupil)
        {
            return new PupilBasicInfo
            {
                Id = pupil?.Id,
                Firstname = pupil?.Firstname
            };
        }
    }
}