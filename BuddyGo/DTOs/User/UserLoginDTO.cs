using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class UserLoginDTO {
        [Required]
        public AuthDataDTO AuthData { get; set; } = null!;
    }
}
