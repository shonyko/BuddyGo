using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class User : BaseModel {
        [Required]
        public AuthData AuthData { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
