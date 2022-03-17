using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class UserCreateDTO {
        [Required]
        public AuthDataDTO AuthData { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
