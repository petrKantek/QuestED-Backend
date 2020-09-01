using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.User.Validators
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(45);
        }
    }
}