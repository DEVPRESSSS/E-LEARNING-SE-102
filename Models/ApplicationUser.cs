using System.ComponentModel.DataAnnotations;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class ApplicationUser
    {
        [Key]
        public  string? AppUserId { get; set; }
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? MiddleName { get; set; }
        [Required,MaxLength(50)]
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
    }
}
