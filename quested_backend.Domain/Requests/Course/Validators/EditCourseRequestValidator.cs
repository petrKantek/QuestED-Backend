using FluentValidation;

namespace quested_backend.Domain.Requests.Course.Validators
{
    public class EditCourseRequestValidator : AbstractValidator<EditCourseRequest>
    {
        public EditCourseRequestValidator()
        {
        }
    }
}