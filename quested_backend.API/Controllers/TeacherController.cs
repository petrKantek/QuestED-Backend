using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Conventions;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    [Authorize(Roles = "Teacher, Admin")]
    [JsonException]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        
        [HttpGet]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Get))]
        public async Task<IActionResult> Get()
        {
            var result = await _teacherService.GetTeachersAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        [TeacherExists]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Get))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _teacherService.GetTeacherAsync(
                new GetTeacherRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Create))]
        public async Task<IActionResult> Post(AddTeacherRequest request)
        {
            var result = await _teacherService.AddTeacherAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Update))]
        public async Task<IActionResult> Put(EditTeacherRequest request)
        {
            var result = await _teacherService.EditTeacherAsync(request);
            return Ok(result);
        }

        [HttpPut("score")]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Update))]
        public async Task<IActionResult> EditScore(EditScoreRequest request)
        {
            await _teacherService.EditScore(request);
            return Ok();
        }

        [HttpGet("score")]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Get))]
        public async Task<IActionResult> GetPupilScore(GetPupilScoreRequest request)
        {
            var score = await _teacherService.GetPupilScore(request);
            return Ok(score);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [TeacherExists]
        [ApiConventionMethod(typeof(QuestedApiConventions),
            nameof(QuestedApiConventions.Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedTeacher = await _teacherService.DeleteTeacherById(id);
            return Ok(deletedTeacher);
        }
    }
}