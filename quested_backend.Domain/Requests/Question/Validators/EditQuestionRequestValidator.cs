using FluentValidation;

namespace quested_backend.Domain.Requests.Question.Validators
{
    public class EditQuestionRequestValidator : AbstractValidator<EditQuestionRequest>
    {
        public EditQuestionRequestValidator()
        {
        }
    }
}