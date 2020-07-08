namespace quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses
{
    public class AnswerBasicInfo
    {
        public int? AchievedPoints { get; set; }

        public PupilBasicInfo AnsweredBy { get; set; }
    }
}