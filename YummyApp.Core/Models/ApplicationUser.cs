using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YummyApp.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(24)]
        public string FirstName { get; set; }

        [Required, MaxLength(24)]
        public string LastName { get; set; }

        public string? ImageName { get; set; }

        public string? JobTitle { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public UserType UserType { get; set; }

        [Required]
        public int Status { get; set; } = 1;

        [Required]
        public int Blocked { get; set; } = 0;
    }

    public enum UserType
    {
        Administrator,
        Chef,
        User
    }
}
