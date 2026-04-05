using Microsoft.EntityFrameworkCore;
using ELearningApp.Data;
using ELearningApp.DTOs;
using ELearningApp.Models;

namespace ELearningApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CreateCourse(CreateCourseDto dto, int userId)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = userId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<List<CourseResponseDto>> GetCourses()
        {
            return await _context.Courses
                .AsNoTracking()
                .Select(c => new CourseResponseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorName = c.Instructor.Name
                })
                .ToListAsync();
        }

        public async Task<CourseDetailsDto?> GetCourseById(int id)
        {
            return await _context.Courses
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
        }
    }
}