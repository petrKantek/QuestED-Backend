using System.Collections.Generic;

namespace quested_backend.Domain.Requests.Question
{
    public class AddQuestionRequest
    {
        public int EpisodeId { get; set; }
        
        public int EpisodeSeasonId { get; set; }
        
        public int? MaxPoints { get; set; }
        
        //public virtual ICollection<int> PupilInCourseAnswersQuestionIds { get; set; }
    }
}