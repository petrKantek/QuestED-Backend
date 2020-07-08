using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class AddTeacherToSchoolRequestValidator : AbstractValidator<AddTeacherToSchoolRequest>
    {
        public AddTeacherToSchoolRequestValidator()
        {
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0);
        }
    }
}