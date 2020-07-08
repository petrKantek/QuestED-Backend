using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class SchoolResponse : SchoolBasicInfo
    {
        public IEnumerable<string> HasSeasons { get; set; }

        public IEnumerable<TeacherBasicInfo> HasTeachers { get; set; }
    }
}