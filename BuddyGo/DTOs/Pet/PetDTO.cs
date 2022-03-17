namespace BuddyGo.DTOs.Pet {
    public class PetDTO : BaseDTO {
        public string Name { get; set; }
        public string Sex { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public string OwnerId { get; set; }
    }
}
