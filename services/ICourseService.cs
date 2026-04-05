using ELearningApp.DTOs;

namespace ELearningApp.Services
{
    public interface ICourseService
    {
        Task<object> CreateCourse(CreateCourseDto dto, int userId);
        Task<List<CourseResponseDto>> GetCourses();
        Task<CourseDetailsDto?> GetCourseById(int id);
    }
}