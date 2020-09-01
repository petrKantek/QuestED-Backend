using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Teacher.Validators
{
    public class EditScoreRequestValidator : AbstractValidator<EditScoreRequest>
    {
        public EditScoreRequestValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EpisodeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PupilId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.QuestionId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NewScore).NotEmpty().GreaterThan(0);
        }
    }
}