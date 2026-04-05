using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ELearningApp.Data;
using ELearningApp.Models;
using ELearningApp.DTOs;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace ELearningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // Admin only
       [Authorize(Roles = "Admin,Instructor")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                return Unauthorized();

            var userId = int.Parse(claim.Value);

            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = userId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CourseDetailsDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Students = c.Enrollments
                        .Select(e => e.User.Name)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        //  Get all courses
       [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .Select(c => new CourseResponseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorName = c.Instructor.Name
                })
                .ToListAsync();

            return Ok(courses);
        }
    }
}