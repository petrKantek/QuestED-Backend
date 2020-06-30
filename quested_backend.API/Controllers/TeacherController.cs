using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    [JsonException]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _teacherService.GetTeachersAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _teacherService.GetTeacherAsync(
                new GetTeacherRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTeacherRequest schoolRequest)
        {
            var result = await _teacherService.AddTeacherAsync(schoolRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EditTeacherRequest schoolRequest)
        {
            schoolRequest.Id = id;
            var result = await _teacherService.EditTeacherAsync(schoolRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditScore(EditScoreRequest request)
        {
            await _teacherService.EditScore(request);
            return Ok();
        }

        public async Task<IActionResult> AddPupilToClass(AddPupilToClassRequest request)
        {
            await _teacherService.AddPupilToClass(request);
            return Ok();
        }

        public async Task<IActionResult> GetPupilScore(GetPupilScoreRequest request)
        {
            var score = await _teacherService.GetPupilScore(request);
            return Ok(score);
        }
    }
}