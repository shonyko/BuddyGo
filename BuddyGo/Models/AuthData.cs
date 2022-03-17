using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class AuthData : BaseModel {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
    }
}
