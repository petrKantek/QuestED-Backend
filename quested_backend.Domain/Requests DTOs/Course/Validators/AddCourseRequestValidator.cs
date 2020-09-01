using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.Course.Validators
{
    public class AddCourseRequestValidator : AbstractValidator<AddCourseRequest>
    {
        public AddCourseRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}