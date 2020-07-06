using FluentValidation;

namespace quested_backend.Domain.Requests.Season.Validators
{
    public class EditSeasonRequestValidator : AbstractValidator<EditSeasonRequest>
    {
        public EditSeasonRequestValidator()
        {
        }
    }
}