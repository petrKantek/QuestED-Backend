using FluentValidation;

namespace quested_backend.Domain.Requests.Teacher.Validators
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