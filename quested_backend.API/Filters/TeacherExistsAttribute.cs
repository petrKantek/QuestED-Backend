using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    /// <summary>
    /// User-defined attribute, performs validation of Teacher entity
    /// </summary>
    public class TeacherExistsAttribute : TypeFilterAttribute
    {
        public TeacherExistsAttribute() : base(typeof(TeacherExistsFilterImpl))
            { }

        /// <summary>
        /// Action filter, performs validation on Teacher entity
        /// </summary>
        private class TeacherExistsFilterImpl : IAsyncActionFilter
        {
            private readonly ITeacherService _teacherService;

            public TeacherExistsFilterImpl(ITeacherService teacherService)
            {
                _teacherService = teacherService;
            }

            /// <summary>
            /// Performs validation of the current action context
            /// </summary>
            /// <param name="context">context for action filters</param>
            /// <param name="next">next item in the middleware pipeline</param>
            /// <returns>
            /// BadRequest if context does not contain ID field
            /// or it is not in range [ 1, 2.147.483.647 ],
            /// NotFoundObjectResult if there is no Teacher
            /// with given id, otherwise the middleware pipeline
            /// continues with the next delegate
            /// </returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestObjectResult("Request must contain a teacher ID in range [ 1, 2.147.483.647 ]");
                    return;
                }

                var result = await _teacherService
                    .ReadOnlyGetTeacherAsync(new GetTeacherRequest {Id = id});

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult($"Teacher with id {id} does not exist in the database");
                    return;
                }

                await next();
            }
        }
    }
}