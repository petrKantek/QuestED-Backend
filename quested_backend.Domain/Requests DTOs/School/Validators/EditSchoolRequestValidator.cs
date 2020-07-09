using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class EditSchoolRequestValidator : AbstractValidator<EditSchoolRequest>
    {
        public EditSchoolRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleForEach(x => x.TeacherIds).GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("All teachers must exist in the database");
        }
    }
}