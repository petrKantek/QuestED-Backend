using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    public class ClassExistsAttribute : TypeFilterAttribute
    {
        public ClassExistsAttribute() : base(typeof(ClassExistsFilterImpl))
            { }

        private class ClassExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IClassService _classService;

            public ClassExistsFilterImpl(IClassService classService)
            {
                _classService = classService;
            }
            
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = await _classService.GetClassAsync(new GetClassRequest {Id = id});

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