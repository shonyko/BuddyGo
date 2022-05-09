using BuddyGo.DTOs.User;

namespace BuddyGo.DTOs.Sitter {
    public class SitterCreateDTO : UserCreateDTO {
        public string Description { get; set; } = string.Empty;
    }
}
