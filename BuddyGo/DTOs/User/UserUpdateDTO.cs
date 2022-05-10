namespace BuddyGo.DTOs.User {
    public class UserUpdateDTO {
        public AuthDataDTO AuthData { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
