using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    /// <summary>
    /// General construction of user-defined attributes
    /// </summary>
    public class ClassExistsAttribute : TypeFilterAttribute
    {
        public ClassExistsAttribute() : base(typeof(ClassExistsFilterImpl))
            { }

        /// <summary>
        /// Action filter, performs checks on Class entity
        /// </summary>
        private class ClassExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IClassService _classService;

            public ClassExistsFilterImpl(IClassService classService)
            {
                _classService = classService;
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

                var result = await _classService.ReadOnlyGetClassAsync(new GetClassRequest {Id = id});

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult($"Class with id {id} does not exist in the database");
                    return;
                }

                await next();
            }
        }
    }
}