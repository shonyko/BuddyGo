using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class User : BaseModel {
        [Required]
        public AuthData AuthData { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
    }
}
