using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Season.Validators
{
    public class AddSeasonRequestValidator : AbstractValidator<AddSeasonRequest>
    {
        public AddSeasonRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
        }
    }
}