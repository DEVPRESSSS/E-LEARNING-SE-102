using System.ComponentModel.DataAnnotations;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class Lesson
    {
        [Key]
        public string? LessonId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
