using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Filters;

namespace quested_backend.Controllers
{
    [ApiController]
    [Route("api/courses")]
    [Authorize(Roles = "Admin, Teacher")]
    [JsonException]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _courseService.GetCoursesAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        [CourseExists]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _courseService.GetCourseAsync(
                new GetCourseRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(AddCourseRequest schoolRequest)
        {
            var result = await _courseService.AddCourseAsync(schoolRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditCourseRequest schoolRequest)
        {
            var result = await _courseService.EditCourseAsync(schoolRequest);
            return Ok(result);
        }

        [HttpGet("avg/{id:int}")]
        [CourseExists]
        public async Task<IActionResult> GetAvgScore(int id)
        {
            var avgScores = await _courseService.GetAvgScoreOfPupils(id);
            return Ok(avgScores);
        }
        
        [HttpGet("scores/{id:int}")]
        [CourseExists]
        public async Task<IActionResult> GetScores(int id)
        {
            var avgScores = await _courseService.GetScoresOfAllPupils(id);
            return Ok(avgScores);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [CourseExists]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCourse = await _courseService.DeleteCourseById(id);
            return Ok(deletedCourse);
        }
    }
}