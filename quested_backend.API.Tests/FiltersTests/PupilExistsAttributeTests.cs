using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;
using Xunit;

namespace quested_backend.API.Tests.FiltersTests
{
    public class PupilExistsAttributeTests
    {
        [Fact]
        public async Task should_continue_pipeline_when_id_is_present()
        {
            const int id = 2;
            var pupilService = new Mock<IPupilService>();

            pupilService
                .Setup(x =>
                    x.ReadOnlyGetPupilAsync(It.IsAny<GetPupilRequest>()))
                .ReturnsAsync(new PupilResponse());

            var filter = new PupilExistsAttribute.
                PupilExistsFilterImpl(pupilService.Object);
            
            var actionExecutedContext = new ActionExecutingContext(new ActionContext(new DefaultHttpContext(),
                new RouteData(), new ActionDescriptor() ),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    { "id", id }
                }, new object());

            var nextCallback = new Mock<ActionExecutionDelegate>();
            await filter.OnActionExecutionAsync(actionExecutedContext, nextCallback.Object);
            
            nextCallback.Verify(executionDelegate => executionDelegate(), Times.Once);
        }
    }
}