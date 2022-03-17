using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IPetRepository {
        public Task CreatePet(Pet pet);

        public Task<Pet> GetPetById(string id);

        public IEnumerable<Pet> GetAllPets();
        public Task UpdatePet(Pet pet);

        public Task DeletePet(Pet pet);
    }
}
