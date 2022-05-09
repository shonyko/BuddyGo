namespace BuddyGo.Models {
    public class Owner : User {
        public List<Pet> Pets { get; set; } = null!;
        public bool IsOwner { get; set; } = true;
    }
}
