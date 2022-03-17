using BuddyGo.DTOs.Owner;

namespace BuddyGo.Services {
    public interface IOwnerService {
        public Task<OwnerDTO> CreateOwner(OwnerCreateDTO owner);

        public Task<OwnerDTO> GetOwnerById(string id);

        public IEnumerable<OwnerDTO> GetAllOwners();
        public Task<bool> UpdateOwner(string id, OwnerUpdateDTO owner);

        public Task<bool> DeleteOwner(string id);
    }
}
