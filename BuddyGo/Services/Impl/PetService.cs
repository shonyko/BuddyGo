using AutoMapper;
using BuddyGo.DTOs.Pet;
using BuddyGo.Models;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class PetService : BaseService<Pet, PetDTO, PetCreateDTO, PetUpdateDTO>, IPetService {
        private readonly IPetRepository _repository;
        //private readonly IMapper _mapper;
        
        public PetService(IPetRepository repository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
            //_mapper = mapper;
        }

        //public async Task<PetDTO> Create(PetCreateDTO pet) {
        //    var mappedPet = _mapper.Map<Pet>(pet);

        //    await _repository.Create(mappedPet);
        //    return _mapper.Map<PetDTO>(mappedPet);
        //}

        //public async Task<bool> Delete(string id) {
        //    var pet = await _repository.GetById(id);
        //    if (pet == null) return false;

        //    await _repository.Delete(pet);
        //    return true;
        //}

        //public IEnumerable<PetDTO> GetAll() {
        //    var pets = _repository.GetAll();
        //    return _mapper.Map<List<PetDTO>>(pets);
        //}

        //public async Task<PetDTO> GetById(string id) {
        //    var pet = await _repository.GetById(id);
        //    return _mapper.Map<PetDTO>(pet);
        //}

        //public async Task<bool> Update(string id, PetUpdateDTO pet) {
        //    var fromRepo = await _repository.GetById(id);
        //    if (fromRepo == null) return false;
        //    _mapper.Map(pet, fromRepo);
        //    await _repository.Update(fromRepo);
        //    return true;
        //}
    }
}
