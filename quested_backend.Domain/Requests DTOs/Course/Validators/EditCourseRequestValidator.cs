using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Course.Validators
{
    public class EditCourseRequestValidator : AbstractValidator<EditCourseRequest>
    {
        public EditCourseRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}