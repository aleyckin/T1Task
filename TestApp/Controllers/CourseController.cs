using Contracts.Dtos;
using Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAllCourses()
        {
            return await _courseService.GetAllCoursesAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourses([FromBody] CourseDto courseDto)
        {
            return await _courseService.CreateCourseAsync(courseDto);
        }

        [HttpPost("/{courseId:guid}/students")]
        public async Task<ActionResult<Guid>> AddToCourseNewStudent([FromRoute] Guid courseId, [FromBody] StudentDto studentDto)
        {
            return await _courseService.AddToCourseNewStudentAsync(courseId, studentDto);
        }

        [HttpDelete("/{courseId:guid}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid courseId)
        {
            await _courseService.DeleteCourseAsync(courseId);
            return Ok();
        }
    }
}
