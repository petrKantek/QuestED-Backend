using FluentValidation;

namespace quested_backend.Domain.Requests.Pupil.Validators
{
    public class GetPupilScoreRequestValidator : AbstractValidator<GetPupilScoreRequest>
    {
        public GetPupilScoreRequestValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EpisodeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PupilId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.QuestionId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
        }
    }
}