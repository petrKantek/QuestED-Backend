using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.Course;
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

        [HttpPut("{id:int}")] 
        public async Task<IActionResult> Put(int id, EditCourseRequest schoolRequest)
        {
            schoolRequest.Id = id;
            var result = await _courseService.EditCourseAsync(schoolRequest);
            return Ok(result);
        }
    }
}