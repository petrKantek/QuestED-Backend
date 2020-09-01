using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Question.Validators
{
    public class EditQuestionRequestValidator : AbstractValidator<EditQuestionRequest>
    {
        public EditQuestionRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EpisodeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.MaxPoints).GreaterThan(0);
            RuleFor(x => x.EpisodeSeasonId).NotEmpty().GreaterThan(0);
        }
    }
}