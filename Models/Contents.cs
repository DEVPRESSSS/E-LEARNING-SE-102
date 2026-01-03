using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class Contents
    {

        [Key]
        public string? ContentId { get; set; } 

        [Required(ErrorMessage ="Description is required")]
        [MaxLength(500)]
        public string? Description { get; set; }

        // File info
        [Required,MaxLength(100)]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        public string? FileType { get; set; } 

        public DateTime?UploadedAt { get; set; }

        [Required]
        public string? LessonId { get; set; }

        [ForeignKey("LessonId")]
        [ValidateNever]
        public Lesson Lesson { get; set; } = null!;
    }
}
