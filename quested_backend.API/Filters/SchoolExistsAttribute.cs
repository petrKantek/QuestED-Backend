using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    /// <summary>
    /// General construction of user-defined attributes
    /// </summary>
    public class SchoolExistsAttribute : TypeFilterAttribute
    {
        public SchoolExistsAttribute() : base(typeof(SchoolExistsFilterImpl))
            { }

        /// <summary>
        /// Action filter, performs checks on School entity
        /// </summary>
        private class SchoolExistsFilterImpl : IAsyncActionFilter
        {
            private readonly ISchoolService _schoolService;

            public SchoolExistsFilterImpl(ISchoolService schoolService)
            {
                _schoolService = schoolService;
            }
            
            /// <summary>
            /// Performs checks of the current action context 
            /// </summary>
            /// <param name="context">context for action filters</param>
            /// <param name="next">next item in the middleware pipeline</param>
            /// <returns>
            /// BadRequest if context does not contain id field,
            /// NotFoundObjectResult is there is no pupil
            /// with given id, nothing otherwise
            /// </returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
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