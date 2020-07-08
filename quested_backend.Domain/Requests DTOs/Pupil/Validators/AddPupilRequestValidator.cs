using FluentValidation;

namespace quested_backend.Domain.Requests_DTOs.Pupil.Validators
{
    /// <summary>
    /// Validator for attributes of add pupil request
    /// </summary>
    public class AddPupilRequestValidator : AbstractValidator<AddPupilRequest>
    {
        public AddPupilRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
        }
    }
}