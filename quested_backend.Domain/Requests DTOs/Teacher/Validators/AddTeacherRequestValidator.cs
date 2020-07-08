using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.Teacher.Validators
{
    public class AddTeacherRequestValidator : AbstractValidator<AddTeacherRequest>
    {
        private readonly ISchoolService _schoolService;
        public AddTeacherRequestValidator(ISchoolService schoolService)
        {
            _schoolService = schoolService;
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0)
                .MustAsync(SchoolExists).WithMessage("School must exist in the database");
        }

        private async Task<bool> SchoolExists(int schoolId, CancellationToken cancellationToken)
        {
            var school = await _schoolService.GetSchoolAsync(new GetSchoolRequest
            {
                Id = schoolId
            });

            return school != null;
        }
    }
}