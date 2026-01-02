using System.ComponentModel.DataAnnotations;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class Courses
    {
        [Key]
        public string? CourseId { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        public DateTime? CreatedAt { get; set; }
      
    }
}
