using BuddyGo.DTOs.Pet;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface IPetService : IService<Pet, PetDTO, PetCreateDTO, PetUpdateDTO> {
        //public Task<PetDTO> Create(PetCreateDTO pet);

        //public Task<PetDTO> GetById(string id);

        //public IEnumerable<PetDTO> GetAll();
        //public Task<bool> Update(string id, PetUpdateDTO pet);

        //public Task<bool> Delete(string id);
    }
}
