namespace ELearningApp.DTOs
{
    public class CourseCreatedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }
    }
}