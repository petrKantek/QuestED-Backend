using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class Question
    {
        public Question()
        {
            PupilInCourseAnswersQuestion = new HashSet<PupilInCourseAnswersQuestion>();
        }

        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public int EpisodeSeasonId { get; set; }
        public int? MaxPoints { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual ICollection<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
    }
}
