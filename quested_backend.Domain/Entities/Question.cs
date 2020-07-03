using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Question. It contains maximum number of points
    /// attainable from this question. Each question has references to episode
    /// and season it belongs to. It also has a collection of answers to this question.
    /// </summary>
    public partial class Question : BaseEntity
    {
        public Question()
        {
            PupilInCourseAnswersQuestion = new HashSet<PupilInCourseAnswersQuestion>();
        }
        public int? MaxPoints { get; set; }
        
        /* relationships */
        public int EpisodeId { get; set; }
        public int EpisodeSeasonId { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual ICollection<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
    }
}
