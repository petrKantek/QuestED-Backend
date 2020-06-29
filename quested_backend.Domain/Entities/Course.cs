using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class Course : BaseEntity
    {
        public Course()
        {
            PupilInCourse = new HashSet<PupilInCourse>();
        }
        public int TeacherId { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public virtual Season Season { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
