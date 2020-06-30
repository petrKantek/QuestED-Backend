namespace quested_backend.Domain.Requests.Pupil
{
    public class GetPupilScoreRequest
    {
        public int PupilId { get; set; }

        public int CourseId { get; set; }

        public int QuestionId { get; set; }

        public int EpisodeId { get; set; }

        public int SeasonId { get; set; }
    }
}