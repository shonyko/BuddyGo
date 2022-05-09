using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs.Pet {
    public class PetCreateDTO {
        public string Name { get; set; } = null!;
        [StringLength(1, ErrorMessage = "Sex must be either M/F.")]
        public string Sex { get; set; } = null!;
        public float Weight { get; set; }
        public int Age { get; set; }
        public string Description { get; set; } = null!;

        public string OwnerId { get; set; } = null!;
    }
}
