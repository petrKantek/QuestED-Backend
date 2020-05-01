using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class PupilInCourseAnswersQuestion
    {
        public int PupilInCourseCourseId { get; set; }
        public int PupilInCoursePupilId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionEpisodeId { get; set; }
        public int QuestionEpisodeSeasonId { get; set; }
        public string AchievedPoints { get; set; }

        public virtual PupilInCourse PupilInCourse { get; set; }
        public virtual Question Question { get; set; }
    }
}
