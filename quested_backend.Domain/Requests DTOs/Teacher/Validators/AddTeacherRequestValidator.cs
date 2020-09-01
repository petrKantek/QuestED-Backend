using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Teacher.Validators
{
    public class AddTeacherRequestValidator : AbstractValidator<AddTeacherRequest>
    {
        public AddTeacherRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.SchoolExists).WithMessage("School must exist in the database");
        }
    }
}