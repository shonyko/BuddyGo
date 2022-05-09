using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class UserDTO : BaseDTO {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
