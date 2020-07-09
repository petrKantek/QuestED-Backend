using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Class.Validators
{
    public class AddClassRequestValidator : AbstractValidator<AddClassRequest>
    {
        public AddClassRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}