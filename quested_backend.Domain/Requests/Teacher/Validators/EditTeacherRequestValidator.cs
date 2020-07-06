using FluentValidation;

namespace quested_backend.Domain.Requests.Teacher.Validators
{
    public class EditTeacherRequestValidator : AbstractValidator<EditTeacherRequest>
    {
        public EditTeacherRequestValidator()
        {
        }
    }
}