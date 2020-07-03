namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing answer to question. It contains the amount of points
    /// obtained. It has references to pupil who made the answer, course which the question
    /// belongs to, the question itself, episode and season in which it was answered.
    /// </summary>
    public partial class PupilInCourseAnswersQuestion
    {
        public int AchievedPoints { get; set; }
        
        /* relationships */
        public int PupilInCourseCourseId { get; set; }
        public int PupilInCoursePupilId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionEpisodeId { get; set; }
        public int QuestionEpisodeSeasonId { get; set; }
        public virtual PupilInCourse PupilInCourse { get; set; }
        public virtual Question Question { get; set; }
    }
}
