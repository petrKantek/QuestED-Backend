using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class AddTeacherToSchoolRequestValidator : AbstractValidator<AddTeacherToSchoolRequest>
    {
        private readonly ISchoolService _schoolService;
        private readonly ITeacherService _teacherService;
        public AddTeacherToSchoolRequestValidator(ISchoolService schoolService, ITeacherService teacherService)
        {
            _schoolService = schoolService;
            _teacherService = teacherService;
            RuleFor(x => x.SchoolId).NotEmpty().GreaterThan(0)
                .MustAsync(SchoolExists).WithMessage("School must exist in the database");
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(TeacherExists).WithMessage("Teacher must exist in the database");
        }

        private async Task<bool> SchoolExists(int schoolId, CancellationToken cancellationToken)
        {
            var school = await _schoolService.GetSchoolAsync(new GetSchoolRequest
            {
                Id = schoolId
            });

            return school != null;
        }
        
        private async Task<bool> TeacherExists(int teacherId, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.GetTeacherAsync(new GetTeacherRequest
            {
                Id = teacherId
            });

            return teacher != null;
        }
        
    }
}