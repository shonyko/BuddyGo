using BuddyGo.DTOs.Pet;
using BuddyGo.DTOs.User;

namespace BuddyGo.DTOs.Owner {
    public class OwnerDTO : UserDTO {
        public bool IsOwner { get; set; }
        public List<PetDTO> Pets { get; set; } = null!;
    }
}
