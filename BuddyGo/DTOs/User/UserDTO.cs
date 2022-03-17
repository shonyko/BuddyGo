using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.User {
    public class UserDTO : BaseDTO {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
