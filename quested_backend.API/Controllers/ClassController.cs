using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [Route("api/classes")]
    [Authorize(Roles = "Admin, Teacher")]
    [ApiController]
    [JsonException]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        
        [HttpGet]
        [Authorize(Roles = "Student, Admin, Teacher")]
        public async Task<IActionResult> Get()
        {
            var result = await _classService.GetClassesAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Student, Admin, Teacher")]
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

        [HttpPut]
        public async Task<IActionResult> Put(EditClassRequest classRequest)
        {
            var result = await _classService.EditClassAsync(classRequest);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ClassExists]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedClass = await _classService.DeleteClassById(id);
            return Ok(deletedClass);
        }
    }
}