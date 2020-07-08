using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class TeacherResponse : TeacherBasicInfo
    {
        public virtual SchoolBasicInfo TeachesInSchool { get; set; }
        public IEnumerable<CourseBasicInfo> TeachesCourses { get; set; }
    }
}