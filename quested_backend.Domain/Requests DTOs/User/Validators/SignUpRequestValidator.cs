using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.User.Validators
{
    public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(45);
        }
    }
}