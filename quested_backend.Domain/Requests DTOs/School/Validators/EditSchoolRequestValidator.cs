using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs.School.Validators
{
    public class EditSchoolRequestValidator : AbstractValidator<EditSchoolRequest>
    {
        private readonly ITeacherService _teacherService;
        public EditSchoolRequestValidator(ITeacherService teacherService)
        {
            _teacherService = teacherService;
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleForEach(x => x.TeacherIds).GreaterThan(0)
                .MustAsync(TeacherExists).WithMessage("All teachers must exist in the database");
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