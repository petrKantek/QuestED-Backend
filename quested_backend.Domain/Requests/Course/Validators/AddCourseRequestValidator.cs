using System.Data;
using FluentValidation;

namespace quested_backend.Domain.Requests.Course.Validators
{
    public class AddCourseRequestValidator : AbstractValidator<AddCourseRequest>
    {
        public AddCourseRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SeasonId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}