using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.User.Validators
{
    public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(45);
        }
    }
}