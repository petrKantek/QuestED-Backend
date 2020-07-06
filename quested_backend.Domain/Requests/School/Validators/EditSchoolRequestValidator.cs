using FluentValidation;

namespace quested_backend.Domain.Requests.School.Validators
{
    public class EditSchoolRequestValidator : AbstractValidator<EditSchoolRequest>
    {
        public EditSchoolRequestValidator()
        {
        }
    }
}