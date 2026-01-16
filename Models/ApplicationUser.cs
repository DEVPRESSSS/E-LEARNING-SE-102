using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_LEARNING_SE_102_PROJECT.Models
{
    public class ApplicationUser: IdentityUser
    {
    
        [Required, MaxLength(20)]
        public string? FirstName { get; set; }
        [Required, MaxLength(20)]
        public string? MiddleName { get; set; }
        [Required,MaxLength(20)]
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
    }
}
