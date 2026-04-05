using System.ComponentModel.DataAnnotations;

namespace ELearningApp.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int InstructorId { get; set; }
    }
}