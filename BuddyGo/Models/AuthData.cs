using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class AuthData : BaseModel {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; } = string.Empty;

        public override bool Equals(Object obj) {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }

            var data = (AuthData) obj;
            return (Username.Equals(data.Username)) && (Password.Equals(data.Password));
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Username, Password, Salt);
        }
    }
}
