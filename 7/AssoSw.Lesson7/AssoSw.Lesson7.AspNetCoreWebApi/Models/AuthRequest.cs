using System.ComponentModel.DataAnnotations;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
