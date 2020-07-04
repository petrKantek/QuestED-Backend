using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.Pupil;
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
        public async Task<IActionResult> Get()
        {
            var result = await _pupilService.GetPupilsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [PupilExists]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pupilService.ReadOnlyGetPupilAsync(
                new GetPupilRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> Post(AddPupilRequest pupilRequest)
        {
            var result = await _pupilService.AddPupilAsync(pupilRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut("{id:int}")]
        [PupilExists]
        public async Task<IActionResult> Put(int id, EditPupilRequest pupilRequest)
        {
            pupilRequest.Id = id;
            var result = await _pupilService.EditPupilAsync(pupilRequest);
            return Ok(result);
        }
    }
}