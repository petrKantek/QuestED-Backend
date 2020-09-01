using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class AddTeacherToSchoolRequestValidator : AbstractValidator<AddTeacherToSchoolRequest>
    {
        public AddTeacherToSchoolRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.SchoolExists).WithMessage("School must exist in the database");
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}