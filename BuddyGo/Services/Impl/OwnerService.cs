using AutoMapper;
using BuddyGo.DTOs.Announcement;
using BuddyGo.DTOs.Owner;
using BuddyGo.DTOs.Pet;
using BuddyGo.Models;
using BuddyGo.Repositories;
using BuddyGo.Utils;

namespace BuddyGo.Services.Impl {
    public class OwnerService : GenericUserService<Owner, OwnerDTO, OwnerCreateDTO, OwnerUpdateDTO, OwnerLoginDTO>, IOwnerService {
        private readonly IOwnerRepository _repository;
        private readonly IPetRepository _petRepository;
        private readonly IAnnouncementRepository _announcementRepository;
        //private readonly IMapper _mapper;
        //private readonly IPasswordEncryptor _passwordEncryptor;
        public OwnerService(IOwnerRepository repository, IPetRepository petRepository, IAnnouncementRepository announcementRepository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
            _petRepository = petRepository;
            _announcementRepository = announcementRepository;
            //_mapper = mapper;
            //_passwordEncryptor = passwordEncryptor;
        }

        public async Task<List<AnnouncementDTO>> GetAnnouncements(string id) {
            return _mapper.Map<List<Announcement>, List<AnnouncementDTO>>(await _announcementRepository.GetAllByOwnerId(id));
        }

        public async Task<List<PetDTO>> GetPets(string id) {
            return _mapper.Map<List<Pet>, List<PetDTO>>(await _petRepository.GetAllByOwnerId(id));
        }

        //// TODO: De mutat password encryption in repo maybe
        //public async Task<OwnerDTO> Create(OwnerCreateDTO owner) {
        //    var mappedOwner = _mapper.Map<Owner>(owner);

        //    //_passwordEncryptor.CreatePasswordHash(owner.AuthData.Password, out byte[] hash, out byte[] salt);
        //    //var authData = new AuthData {
        //    //    Username = owner.AuthData.Username,
        //    //    Password = System.Text.Encoding.UTF8.GetString(hash),
        //    //    Salt = System.Text.Encoding.UTF8.GetString(salt)
        //    //};
        //    //mappedOwner.AuthData = authData;

        //    await _repository.Create(mappedOwner);
        //    return _mapper.Map<OwnerDTO>(mappedOwner);
        //}

        //public async Task<bool> Delete(string id) {
        //    var owner = await _repository.GetById(id);
        //    if (owner == null) return false;

        //    await _repository.Delete(owner);
        //    return true;
        //}

        //public IEnumerable<OwnerDTO> GetAll() {
        //    var owners = _repository.GetAll();
        //    return _mapper.Map<List<OwnerDTO>>(owners);
        //}

        //public async Task<OwnerDTO> GetById(string id) {
        //    var owner = await _repository.GetById(id);
        //    return _mapper.Map<OwnerDTO>(owner);
        //}

        //public async Task<OwnerDTO> GetByLogin(OwnerLoginDTO ownerLoginDTO) {
        //    var mappedOwner = _mapper.Map<Owner>(ownerLoginDTO);
        //    var byLogin = await _repository.GetByLogin(mappedOwner);
        //    return _mapper.Map<OwnerDTO>(byLogin);
        //}

        //public async Task<bool> Update(string id, OwnerUpdateDTO owner) {
        //    var fromRepo = await _repository.GetById(id);
        //    if (fromRepo == null) return false;
        //    _mapper.Map(owner, fromRepo);
        //    await _repository.Update(fromRepo);
        //    return true;
        //}
    }
}
