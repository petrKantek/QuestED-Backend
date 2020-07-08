using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Course. Course has a name and references to the teacher who
    /// teaches the course and season in which the course is taught. It also has a collection
    /// of pupils attending it.
    /// </summary>
    public partial class Course : BaseEntity
    {
        public Course()
        {
            PupilInCourse = new HashSet<PupilInCourse>();
        }
        public string Name { get; set; }
        
        /* relationships */
        public int TeacherId { get; set; }
        
        public int CourseId { get; set; }
        
        public virtual Season CourseNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
