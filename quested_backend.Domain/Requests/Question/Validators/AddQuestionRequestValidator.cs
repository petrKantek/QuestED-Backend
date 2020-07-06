using FluentValidation;

namespace quested_backend.Domain.Requests.Question.Validators
{
    public class AddQuestionRequestValidator : AbstractValidator<AddQuestionRequest>
    {
        public AddQuestionRequestValidator()
        {
            RuleFor(x => x.EpisodeId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EpisodeSeasonId).NotEmpty().GreaterThan(0);
        }
    }
}