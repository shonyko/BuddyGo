using BuddyGo.DTOs.Pet;
using BuddyGo.DTOs.User;

namespace BuddyGo.DTOs.Owner {
    public class OwnerDTO : UserDTO {
        public List<PetDTO> Pets { get; set; } = null!;
        public bool Owner { get; set; }
    }
}
