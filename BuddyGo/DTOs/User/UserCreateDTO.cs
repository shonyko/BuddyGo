using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class UserCreateDTO {
        [Required]
        public AuthDataDTO AuthData { get; set; } = null!;
        public string Name { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
    }
}
