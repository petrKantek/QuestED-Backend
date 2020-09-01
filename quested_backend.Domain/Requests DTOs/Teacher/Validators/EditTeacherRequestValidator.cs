using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Teacher.Validators
{
    public class EditTeacherRequestValidator : AbstractValidator<EditTeacherRequest>
    {
        public EditTeacherRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0);
            RuleForEach(x => x.ClassIds).GreaterThan(0);
            RuleForEach(x => x.CourseIds).GreaterThan(0);
        }
    }
}