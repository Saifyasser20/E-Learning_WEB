using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ELearningApp.Data;
using ELearningApp.Models;
using ELearningApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ELearningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentsController(AppDbContext context)
        {
            _context = context;
        }

        //  Student enroll in course
        [Authorize(Roles = "Student")]
        [HttpPost]
        public async Task<IActionResult> Enroll(CreateEnrollmentDto dto)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                return Unauthorized();

            var userId = int.Parse(claim.Value);

            var exists = await _context.Enrollments
                .AnyAsync(e => e.UserId == userId && e.CourseId == dto.CourseId);

            if (exists)
                return BadRequest("Already enrolled");

            var enrollment = new Enrollment
            {
                UserId = userId,
                CourseId = dto.CourseId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrolled successfully ");
        }
    }
}