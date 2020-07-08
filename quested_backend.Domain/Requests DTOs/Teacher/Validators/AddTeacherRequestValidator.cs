using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Teacher.Validators
{
    public class AddTeacherRequestValidator : AbstractValidator<AddTeacherRequest>
    {
        public AddTeacherRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(45);
        }
    }
}