using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Course
    {
        public Course()
        {
            PupilInCourse = new HashSet<PupilInCourse>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }

        public virtual Season CourseNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PupilInCourse> PupilInCourse { get; set; }
    }
}
