using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class Pet : BaseModel {
        [Required]
        public string Name { get; set; }
        [StringLength(1, ErrorMessage = "Sex must be either M/F.")]
        public string Sex { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
