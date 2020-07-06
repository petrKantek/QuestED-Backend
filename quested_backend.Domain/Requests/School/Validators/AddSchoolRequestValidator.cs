using System.Data;
using FluentValidation;

namespace quested_backend.Domain.Requests.School.Validators
{
    public class AddSchoolRequestValidator : AbstractValidator<AddSchoolRequest>
    {
        public AddSchoolRequestValidator()
        {
            RuleFor(x => x.Country).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            // RuleFor(x => x.SchoolOwnsSeasonIds).NotEmpty();
            // RuleForEach(x => x.SchoolOwnsSeasonIds).NotEmpty().GreaterThan(0);
        }
    }
}