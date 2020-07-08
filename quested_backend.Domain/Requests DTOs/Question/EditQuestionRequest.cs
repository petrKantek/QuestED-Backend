namespace quested_backend.Domain.Requests_DTOs.Question
{
    public class EditQuestionRequest
    {
        public int Id { get; set; }
        
        public int EpisodeId { get; set; }
        
        public int EpisodeSeasonId { get; set; }
        
        public int? MaxPoints { get; set; }
    }
}