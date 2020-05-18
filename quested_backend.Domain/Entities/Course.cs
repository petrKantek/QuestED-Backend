using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class Course
    {
        public Course()
        {
            PupilInCourse = new HashSet<PupilInCourse>();
        }

        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }

        public virtual Season CourseNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
