using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        // Instructor (User)
        public int InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public User Instructor { get; set; }

        // Many-to-Many
        public List<Enrollment> Enrollments { get; set; }
    }
}