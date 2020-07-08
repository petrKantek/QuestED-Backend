using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Class.Validators
{
    public class EditClassRequestValidator : AbstractValidator<EditClassRequest>
    {
        public EditClassRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0);
            //TODO check if teacherId is in DB
        }
    }
}