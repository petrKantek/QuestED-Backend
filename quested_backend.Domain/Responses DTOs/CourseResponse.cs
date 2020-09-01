using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class CourseResponse : CourseBasicInfo
    {
        public string TaughtInSeason { get; set; }

        public TeacherBasicInfo TaughtBy { get; set; }

        public IEnumerable<PupilBasicInfo> EnrolledPupils { get; set; }
    }
}