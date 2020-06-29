using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    public class PupilExistsAttribute : TypeFilterAttribute
    {
        public PupilExistsAttribute() : base(typeof(PupilExistsFilterImpl))
            { }

        public class PupilExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IPupilService _pupilService;

            public PupilExistsFilterImpl(IPupilService pupilService)
            {
                _pupilService = pupilService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = await _pupilService.ReadOnlyGetPupilAsync(new GetPupilRequest {Id = id});

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult($"Pupil with id {id} does not exist in the database");
                    return;
                }

                await next();
            }
        }
    }
}