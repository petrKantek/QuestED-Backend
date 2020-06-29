using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Filters
{
    public class SchoolExistsAttribute : TypeFilterAttribute
    {
        public SchoolExistsAttribute() : base(typeof(SchoolExistsFilterImpl))
            { }

        private class SchoolExistsFilterImpl : IAsyncActionFilter
        {
            private readonly ISchoolService _schoolService;

            public SchoolExistsFilterImpl(ISchoolService schoolService)
            {
                _schoolService = schoolService;
            }
            
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = await _schoolService.GetSchoolAsync(new GetSchoolRequest {Id = id});

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