using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _classService.GetClassesAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ClassExists]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _classService.GetClassAsync(
                new GetClassRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddClassRequest classRequest)
        {
            var result = await _classService.AddClassAsync(classRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut("{id:int}")]
        [ClassExists]
        public async Task<IActionResult> Put(int id, EditClassRequest classRequest)
        {
            classRequest.Id = id;
            var result = await _classService.EditClassAsync(classRequest);
            return Ok(result);
        }
    }
}