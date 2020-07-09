using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class AddSchoolRequestValidator : AbstractValidator<AddSchoolRequest>
    {
        public AddSchoolRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.Country).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleForEach(x => x.TeacherIds).GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("All teachers must exist in the database");
        }
    }
}