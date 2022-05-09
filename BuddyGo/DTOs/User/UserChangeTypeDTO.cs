using BuddyGo.Enums;

namespace BuddyGo.DTOs.User {
    public class UserChangeTypeDTO {
        public string Id { get; set; } = null!;
        public AccountType Type { get; set; }
    }
}
