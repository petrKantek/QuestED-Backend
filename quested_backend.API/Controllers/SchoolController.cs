using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [Route("api/schools")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [JsonException]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _schoolService.GetSchoolsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [SchoolExists]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _schoolService.GetSchoolAsync(
                new GetSchoolRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddSchoolRequest schoolRequest)
        {
            var result = await _schoolService.AddSchoolAsync(schoolRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditSchoolRequest schoolRequest)
        {
            var result = await _schoolService.EditSchoolAsync(schoolRequest);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [SchoolExists]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedSchool = await _schoolService.DeleteSchoolById(id);
            return Ok(deletedSchool);
        }
    }
}