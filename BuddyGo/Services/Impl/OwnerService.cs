using AutoMapper;
using BuddyGo.DTOs.Owner;
using BuddyGo.Models;
using BuddyGo.Repositories;
using BuddyGo.Utils;

namespace BuddyGo.Services.Impl {
    public class OwnerService : IOwnerService {
        private readonly IOwnerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordEncryptor _passwordEncryptor;
        public OwnerService(IOwnerRepository repository, IMapper mapper, IPasswordEncryptor passwordEncryptor) {
            _repository = repository;
            _mapper = mapper;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<OwnerDTO> CreateOwner(OwnerCreateDTO owner) {
            var mappedOwner = _mapper.Map<Owner>(owner);

            _passwordEncryptor.CreatePasswordHash(owner.AuthData.Password, out byte[] hash, out byte[] salt);
            var authData = new AuthData {
                Username = owner.AuthData.Username,
                Password = System.Text.Encoding.UTF8.GetString(hash),
                Salt = System.Text.Encoding.UTF8.GetString(salt)
            };
            mappedOwner.AuthData = authData;

            await _repository.CreateOwner(mappedOwner);
            return _mapper.Map<OwnerDTO>(mappedOwner);
        }

        public async Task<bool> DeleteOwner(string id) {
            var owner = await _repository.GetOwnerById(id);
            if (owner == null) return false;

            await _repository.DeleteOwner(owner);
            return true;
        }

        public IEnumerable<OwnerDTO> GetAllOwners() {
            var owners = _repository.GetAllOwners();
            return _mapper.Map<List<OwnerDTO>>(owners);
        }

        public async Task<OwnerDTO> GetOwnerById(string id) {
            var owner = await _repository.GetOwnerById(id);
            return _mapper.Map<OwnerDTO>(owner);
        }

        public async Task<bool> UpdateOwner(string id, OwnerUpdateDTO owner) {
            var fromRepo = await _repository.GetOwnerById(id);
            if (fromRepo == null) return false;
            _mapper.Map(owner, fromRepo);
            await _repository.UpdateOwner(fromRepo);
            return true;
        }
    }
}
