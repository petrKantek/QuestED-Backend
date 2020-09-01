using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class PupilResponse : PupilBasicInfo
    {
        public IEnumerable<ClassBasicInfo> EnrolledInClasses { get; set; }
        
        public IEnumerable<CourseBasicInfo> EnrolledInCourses { get; set; }
    }
}