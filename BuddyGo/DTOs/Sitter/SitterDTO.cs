using BuddyGo.DTOs.User;

namespace BuddyGo.DTOs.Sitter {
    public class SitterDTO : UserDTO {
        public bool IsSitter { get; set; }
        public string Description { get; set; } = null!;
    }
}
