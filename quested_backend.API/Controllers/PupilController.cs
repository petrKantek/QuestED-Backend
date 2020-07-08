using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [Route("api/pupils")]
    [Authorize(Roles = "Student, Admin, Teacher")]
    [ApiController]
    [JsonException]
    public class PupilController : ControllerBase
    {
        private readonly IPupilService _pupilService;

        public PupilController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> Get()
        {
            var result = await _pupilService.GetPupilsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [PupilExists]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pupilService.ReadOnlyGetPupilAsync(
                new GetPupilRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Post(AddPupilRequest pupilRequest)
        {
            var result = await _pupilService.AddPupilAsync(pupilRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Update))]
        public async Task<IActionResult> Put(EditPupilRequest pupilRequest)
        {
            var result = await _pupilService.EditPupilAsync(pupilRequest);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [PupilExists]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPupil = await _pupilService.DeletePupilById(id);
            return Ok(deletedPupil);
        }
    }
}