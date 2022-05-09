namespace BuddyGo.DTOs.Pet {
    public class PetDTO : BaseDTO {
        public string Name { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public float Weight { get; set; }
        public int Age { get; set; }
        public string Description { get; set; } = null!;

        public string OwnerId { get; set; } = null!;
    }
}
