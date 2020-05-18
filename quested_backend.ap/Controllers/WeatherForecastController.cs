using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Infrastructure;
using quested_backend.Infrastructure.Repositories;

namespace quested_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
     //   private readonly QuestedContext dbContext;
     private readonly IRepository<Pupil, int> _rep;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<Pupil, int> rep)
        {
            _logger = logger;
            _rep = rep;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
        
        [HttpGet("pupil/{id}")]
        public IEnumerable<Pupil> GetPupil(int id)
        {
            var pupils = _rep.GetByIdAsync(id).Result;
            var res = new List<Pupil>();
            res.Add(pupils);
            return res;
        }
    }
}