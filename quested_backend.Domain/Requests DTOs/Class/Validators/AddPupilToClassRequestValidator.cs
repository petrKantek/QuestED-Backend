using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Class.Validators
{
    public class AddPupilToClassRequestValidator : AbstractValidator<AddPupilToClassRequest>
    {
        public AddPupilToClassRequestValidator(IRelatedEntitiesValidator validator)
        {
            RuleFor(x => x.ClassId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PupilId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.PupilExists).WithMessage("Pupil must exist in the database");
            RuleFor(x => x.TeacherId).NotEmpty().GreaterThan(0)
                .MustAsync(validator.TeacherExists).WithMessage("Teacher must exist in the database");
        }
    }
}