using FluentValidation.TestHelper;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Requests.Pupil.Validators;
using Xunit;

namespace Domain.Tests.Requests.Pupil.Validators
{
    public class AddItemRequestValidatorTests
    {
        private readonly AddPupilRequestValidator _validator;

        public AddItemRequestValidatorTests()
        {
            _validator = new AddPupilRequestValidator();
        }

        [Fact]
        public void should_have_error_when_name_is_empty()
        {
            var addPupilRequest = new AddPupilRequest
            {
                Firstname = ""
            };

            _validator.ShouldHaveValidationErrorFor(x => x.Firstname, addPupilRequest);
        }
    }
}