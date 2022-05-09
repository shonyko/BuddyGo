using BuddyGo.DTOs.User;

namespace BuddyGo.DTOs.Sitter {
    public class SitterUpdateDTO : UserUpdateDTO {
        public string Description { get; set; } = null!;
    }
}
