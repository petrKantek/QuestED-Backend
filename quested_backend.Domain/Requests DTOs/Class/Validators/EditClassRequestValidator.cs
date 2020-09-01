using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Class.Validators
{
    public class EditClassRequestValidator : AbstractValidator<EditClassRequest>
    {
        public EditClassRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}