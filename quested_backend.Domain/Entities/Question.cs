using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Question
    {
        public Question()
        {
            PupilInCourseAnswersQuestion = new HashSet<PupilInCourseAnswersQuestion>();
        }

        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public int EpisodeSeasonId { get; set; }
        public int? MaxPoints { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual ICollection<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
    }
}
