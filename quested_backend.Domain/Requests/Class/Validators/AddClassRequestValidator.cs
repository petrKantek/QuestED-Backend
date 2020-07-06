using FluentValidation;

namespace quested_backend.Domain.Requests.Class.Validators
{
    public class AddClassRequestValidator : AbstractValidator<AddClassRequest>
    {
        public AddClassRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
        }
    }
}