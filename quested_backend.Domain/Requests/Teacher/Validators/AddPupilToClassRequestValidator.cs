using FluentValidation;

namespace quested_backend.Domain.Requests.Teacher.Validators
{
    public class AddPupilToClassRequestValidator : AbstractValidator<AddPupilToClassRequest>
    {
        public AddPupilToClassRequestValidator()
        {
            RuleFor(x => x.ClassId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PupilId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0);
        }
    }
}