using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Services;

namespace quested_backend.Controllers
{
    [Route("api/pupils")]
    [ApiController]
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
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pupilService.GetPupilAsync(
                new GetPupilRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPupilRequest pupilRequest)
        {
            var result = await _pupilService.AddPupilAsync(pupilRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EditPupilRequest pupilRequest)
        {
            pupilRequest.Id = id;
            var result = await _pupilService.EditPupilAsync(pupilRequest);
            return Ok(result);
        }
    }
}