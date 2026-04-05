namespace ELearningApp.DTOs
{
    public class CourseDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<string> Students { get; set; }
    }
}