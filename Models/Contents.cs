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
        
    }
}
