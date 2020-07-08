using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Course.Validators
{
    public class EditCourseRequestValidator : AbstractValidator<EditCourseRequest>
    {
        public EditCourseRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0);
            //TODO check teacherId and SeasonID exist in DB
        }
    }
}