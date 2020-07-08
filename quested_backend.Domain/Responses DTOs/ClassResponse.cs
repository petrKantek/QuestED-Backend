using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class ClassResponse : ClassBasicInfo
    { 
        public TeacherBasicInfo TaughtBy { get; set; }
        
        public IEnumerable<PupilBasicInfo> PupilInClass { get; set; }
    }
}