using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    /// <summary>
    /// User-defined attribute, performs validation on Pupil entity
    /// </summary>
    public class PupilExistsAttribute : TypeFilterAttribute
    {
        public PupilExistsAttribute() : base(typeof(PupilExistsFilterImpl))
            { }

        /// <summary>
        /// Action filter, performs validation on Pupil entity
        /// </summary>
        public class PupilExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IPupilService _pupilService;

            public PupilExistsFilterImpl(IPupilService pupilService)
            {
                _pupilService = pupilService;
            }

            /// <summary>
            /// Performs validation of the current action context 
            /// </summary>
            /// <param name="context">context for action filters</param>
            /// <param name="next">next item in the middleware pipeline</param>
            /// <returns>
            /// BadRequest if context does not contain ID field
            /// or it is not in range [ 1, 2.147.483.647 ],
            /// NotFoundObjectResult if there is no Pupil
            /// with given id, otherwise the middleware pipeline
            /// continues with the next delegate
            /// </returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id ) || id <= 0)
                {
                    context.Result = new BadRequestObjectResult("Request must contain a pupil ID in range [ 1, 2.147.483.647 ]");
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