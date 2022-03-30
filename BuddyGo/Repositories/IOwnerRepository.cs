using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IOwnerRepository {
        public Task CreateOwner(Owner owner);

        public Task<Owner> GetOwnerById(string id);
        public Task<Owner> GetOwnerByLogin(Owner owner);

        public IEnumerable<Owner> GetAllOwners();
        public Task UpdateOwner(Owner owner);

        public Task DeleteOwner(Owner owner);
    }
}
