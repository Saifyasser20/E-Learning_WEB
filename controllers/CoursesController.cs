using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ELearningApp.DTOs;
using System.Security.Claims;
using ELearningApp.Services;

namespace ELearningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize(Roles = "Admin,Instructor")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                return Unauthorized();

            var userId = int.Parse(claim.Value);

            var result = await _courseService.CreateCourse(dto, userId);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCourses();
            return Ok(courses);
        }
    }
}