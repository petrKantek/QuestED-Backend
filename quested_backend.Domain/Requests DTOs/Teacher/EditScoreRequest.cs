namespace quested_backend.Domain.Requests_DTOs.Teacher
{
    public class EditScoreRequest
    {
        public int PupilId { get; set; }

        public int CourseId { get; set; }

        public int QuestionId { get; set; }

        public int EpisodeId { get; set; }

        public int SeasonId { get; set; }

        public int NewScore { get; set; }
    }
}