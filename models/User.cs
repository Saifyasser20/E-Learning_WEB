
namespace ELearningApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } 
        
        public List<Course> CreatedCourses { get; set; }  // Instructor

        public List<Enrollment> Enrollments { get; set; } // Student
    }

}