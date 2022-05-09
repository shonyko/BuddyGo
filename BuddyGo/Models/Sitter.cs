namespace BuddyGo.Models {
    public class Sitter : User {
        public string Description { get; set; } = null!;
        public bool IsSitter { get; set; } = true;
    }
}
