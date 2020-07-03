using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Pupil. Pupil can be considered as the central entity of the database.
    /// Pupil only has firstname, but other information can be possible added in the future.
    /// Each pupil has a many-to-many relationship with class and course. 
    /// </summary>
    public class Pupil : BaseEntity
    {
        public Pupil()
        {
            PupilInClass = new HashSet<PupilInClass>();
            PupilInCourse = new HashSet<PupilInCourse>();
        }
        
        public string Firstname { get; set; }

        /* relationships */
        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
