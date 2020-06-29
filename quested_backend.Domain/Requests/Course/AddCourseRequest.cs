using System.Collections.Generic;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Requests.Course
{
    public class AddCourseRequest
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public int SeasonId { get; set; }

    //    public virtual ICollection<int> PupilInCourseIds { get; set; }
    }
}