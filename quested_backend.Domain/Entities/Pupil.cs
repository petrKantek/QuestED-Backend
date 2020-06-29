using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public class Pupil : BaseEntity
    {
        public Pupil()
        {
            PupilInClass = new HashSet<PupilInClass>();
            PupilInCourse = new HashSet<PupilInCourse>();
        }
        
        public string Firstname { get; set; }

        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
