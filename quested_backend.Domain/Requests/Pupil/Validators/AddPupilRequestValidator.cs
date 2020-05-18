using FluentValidation;

namespace quested_backend.Domain.Requests.Pupil.Validators
{
    public class AddPupilRequestValidator : AbstractValidator<AddPupilRequest>
    {
        public AddPupilRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(45);
            
        }
    }
}