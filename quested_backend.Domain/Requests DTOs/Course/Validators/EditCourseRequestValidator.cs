using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.Course.Validators
{
    public class EditCourseRequestValidator : AbstractValidator<EditCourseRequest>
    {
        private readonly ITeacherService _teacherService;
        public EditCourseRequestValidator(ITeacherService teacherService)
        {
            _teacherService = teacherService;
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(TeacherExists).WithMessage("Teacher must exist in the database");
            
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