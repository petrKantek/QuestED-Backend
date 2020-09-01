using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    /// <summary>
    /// User-defined attribute, performs validation on School entity
    /// </summary>
    public class SchoolExistsAttribute : TypeFilterAttribute
    {
        public SchoolExistsAttribute() : base(typeof(SchoolExistsFilterImpl))
            { }

        /// <summary>
        /// Action filter, performs validation on School entity
        /// </summary>
        private class SchoolExistsFilterImpl : IAsyncActionFilter
        {
            private readonly ISchoolService _schoolService;

            public SchoolExistsFilterImpl(ISchoolService schoolService)
            {
                _schoolService = schoolService;
            }
            
            /// <summary>
            /// Performs validation of the current action context 
            /// </summary>
            /// <param name="context">context for action filters</param>
            /// <param name="next">next item in the middleware pipeline</param>
            /// <returns>
            /// BadRequest if context does not contain ID field
            /// or it is not in range [ 1, 2.147.483.647 ],
            /// NotFoundObjectResult if there is no School
            /// with given id, otherwise the middleware pipeline
            /// continues with the next delegate
            /// </returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id) || id <= 0)
                {
                    context.Result = new BadRequestObjectResult("Request must contain a school ID in range [ 1, 2.147.483.647 ]");
                    return;
                }

                var result = await _schoolService.ReadOnlyGetSchoolAsync(new GetSchoolRequest {Id = id});

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult($"School with id {id} does not exist in the database");
                    return;
                }

                await next();
            }
        }
    }
}