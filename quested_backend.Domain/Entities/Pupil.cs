using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Pupil
    {
        public Pupil()
        {
            PupilInClass = new HashSet<PupilInClass>();
            PupilInCourse = new HashSet<PupilInCourse>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }

        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
