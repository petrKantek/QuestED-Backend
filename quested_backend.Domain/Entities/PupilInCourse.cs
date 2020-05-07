using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class PupilInCourse
    {
        public PupilInCourse()
        {
            PupilInCourseAnswersQuestion = new HashSet<PupilInCourseAnswersQuestion>();
        }

        public int CourseId { get; set; }
        public int PupilId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Pupil Pupil { get; set; }
        public virtual ICollection<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
    }
}
