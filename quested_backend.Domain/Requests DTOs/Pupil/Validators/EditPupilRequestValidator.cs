using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Pupil.Validators
{
    /// <summary>
    /// Validator of attributes for edit pupil request
    /// </summary>
    public class EditPupilRequestValidator : AbstractValidator<EditPupilRequest>
    {
        public EditPupilRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}