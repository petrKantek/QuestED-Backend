using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.Class.Validators
{
    public class AddPupilToClassRequestValidator : AbstractValidator<AddPupilToClassRequest>
    {
        private readonly IPupilService _pupilService;
        private readonly ITeacherService _teacherService;
        public AddPupilToClassRequestValidator(IPupilService pupilService, ITeacherService teacherService)
        {
            _pupilService = pupilService;
            _teacherService = teacherService;
            RuleFor(x => x.ClassId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PupilId).NotEmpty().GreaterThan(0)
                .MustAsync(PupilExists).WithMessage("Pupil must exist in the database");
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(TeacherExists).WithMessage("Teacher must exist in the database");
        }

        private async Task<bool> PupilExists(int pupilId, CancellationToken cancellationToken)
        {
            var pupil = await _pupilService.GetPupilAsync(new GetPupilRequest
            {
                Id = pupilId
            });

            return pupil != null;
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