using FluentValidation;

namespace quested_backend.Domain.Requests.Pupil.Validators
{
    public class EditPupilRequestValidator : AbstractValidator<EditPupilRequest>
    {
        public EditPupilRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}