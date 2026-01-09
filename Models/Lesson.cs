using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class Lesson
    {
        [Key]
        public string? LessonId { get; set; }
        [Required (ErrorMessage = "Title is required"),MaxLength(50)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required"), MaxLength(100)]
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;

        //Foreign key
        [Required]
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses? Courses { get; set; }

        //Navigation for courses
        public ICollection<Contents> Contents { get; set; } = new List<Contents> ();
    }
}
