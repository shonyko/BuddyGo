using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class AuthDataDTO {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
