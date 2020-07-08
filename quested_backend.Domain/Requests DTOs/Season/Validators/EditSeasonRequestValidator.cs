using System.Data;
using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Season.Validators
{
    public class EditSeasonRequestValidator : AbstractValidator<EditSeasonRequest>
    {
        public EditSeasonRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleForEach(x => x.CourseIds).GreaterThan(0);
            RuleForEach(x => x.EpisodeIds).GreaterThan(0);
        }
    }
}