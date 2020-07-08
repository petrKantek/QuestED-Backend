using System.Collections.Generic;

namespace quested_backend.Domain.Requests_DTOs.School
{
    public class AddSchoolRequest
    {
        public string Name { get; set; }
        
        public string Country { get; set; }
        
        public virtual ICollection<int> TeacherIds { get; set; }
    }
}