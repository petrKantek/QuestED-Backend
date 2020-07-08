using System.Collections.Generic;

namespace quested_backend.Domain.Requests_DTOs.Course
{
    public class EditCourseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int TeacherId { get; set; }
        public int SeasonId { get; set; }

        // public virtual ICollection<int> PupilInCourseIds { get; set; }
    }
}