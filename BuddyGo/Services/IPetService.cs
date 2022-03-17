using BuddyGo.DTOs.Pet;

namespace BuddyGo.Services {
    public interface IPetService {
        public Task<PetDTO> CreatePet(PetCreateDTO pet);

        public Task<PetDTO> GetPetById(string id);

        public IEnumerable<PetDTO> GetAllPets();
        public Task<bool> UpdatePet(string id, PetUpdateDTO pet);

        public Task<bool> DeletePet(string id);
    }
}
