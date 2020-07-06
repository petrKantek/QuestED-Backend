using System.Collections.Generic;

namespace quested_backend.Domain.Requests.Pupil
{
    public class EditPupilRequest
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        //
        // public virtual ICollection<int> PupilInClassIds { get; set; }
        //
        // public virtual ICollection<int> PupilInCourseIds { get; set; }
    }
}