using AutoMapper;
using BuddyGo.DTOs.Pet;
using BuddyGo.Models;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class PetService : IPetService {
        private readonly IPetRepository _repository;
        private readonly IMapper _mapper;
        
        public PetService(IPetRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PetDTO> CreatePet(PetCreateDTO pet) {
            var mappedPet = _mapper.Map<Pet>(pet);

            await _repository.CreatePet(mappedPet);
            return _mapper.Map<PetDTO>(mappedPet);
        }

        public async Task<bool> DeletePet(string id) {
            var pet = await _repository.GetPetById(id);
            if (pet == null) return false;

            await _repository.DeletePet(pet);
            return true;
        }

        public IEnumerable<PetDTO> GetAllPets() {
            var pets = _repository.GetAllPets();
            return _mapper.Map<List<PetDTO>>(pets);
        }

        public async Task<PetDTO> GetPetById(string id) {
            var pet = await _repository.GetPetById(id);
            return _mapper.Map<PetDTO>(pet);
        }

        public async Task<bool> UpdatePet(string id, PetUpdateDTO pet) {
            var fromRepo = await _repository.GetPetById(id);
            if (fromRepo == null) return false;
            _mapper.Map(pet, fromRepo);
            await _repository.UpdatePet(fromRepo);
            return true;
        }
    }
}
