using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using quested_backend.Conventions;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Infrastructure;
using quested_backend.Infrastructure.Repositories;

namespace quested_backend.Controllers
{
    [ApiController]
    [Route("welcome")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Get))]
        public Dictionary<string, string>  Get()
        {
            
            var mainInformation = new Dictionary<string, string>
            {
                {"welcome_message", "PV178 Project. REST API for Quested."},
                {"swagger documentation: ", "https://localhost:5001/swagger/index.html"}
            };
            return mainInformation;
        }
    }
}