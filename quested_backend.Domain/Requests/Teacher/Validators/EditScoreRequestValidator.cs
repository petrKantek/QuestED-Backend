using FluentValidation;

namespace quested_backend.Domain.Requests.Teacher.Validators
{
    public class EditScoreRequestValidator : AbstractValidator<EditScoreRequest>
    {
        public EditScoreRequestValidator()
        {
        }
    }
}