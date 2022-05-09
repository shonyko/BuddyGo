using AutoMapper;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.DTOs.Owner;
using BuddyGo.DTOs.Sitter;
using BuddyGo.DTOs.User;
using BuddyGo.Enums;
using BuddyGo.Models;

namespace BuddyGo.Services.Impl {
    public class AccountFacade : IAccountFacade {
        private readonly IIncompleteUserService _incompleteUserService;
        private readonly IOwnerService _ownerService;
        private readonly ISitterService _sitterService;
        private readonly IMapper _mapper;

        public AccountFacade(IIncompleteUserService incompleteUserService, IOwnerService ownerService, ISitterService sitterService, IMapper mapper) {
            _incompleteUserService = incompleteUserService;
            _ownerService = ownerService;
            _sitterService = sitterService;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByLogin(UserLoginDTO user) {
            var incompleteUser = await _incompleteUserService.GetByLogin(_mapper.Map<IncompleteUserLoginDTO>(user));
            if (incompleteUser != null) return incompleteUser;

            var owner = await _ownerService.GetByLogin(_mapper.Map<OwnerLoginDTO>(user));
            if(owner != null) return owner;

            var sitter = await _sitterService.GetByLogin(_mapper.Map<SitterLoginDTO>(user));
            if (sitter != null) return sitter;

            return null;
        }

        private async Task<UserDTO> GetByUsername(UserLoginDTO user) {
            var username = user.AuthData.Username;
            var incompleteUser = await _incompleteUserService.GetByUsername(username);
            if (incompleteUser != null) return incompleteUser;

            var owner = await _ownerService.GetByUsername(username);
            if (owner != null) return owner;

            var sitter = await _sitterService.GetByUsername(username);
            if (sitter != null) return sitter;

            return null;
        }

        public async Task<IncompleteUserDTO> Register(UserCreateDTO createDTO) {
            var user = await GetByUsername(_mapper.Map<UserCreateDTO, UserLoginDTO>(createDTO));
            if (user != null) return null;
            return await _incompleteUserService.Create(_mapper.Map<UserCreateDTO, IncompleteUserCreateDTO>(createDTO));
        }
        
        public async Task<UserDTO> SetType(string id, AccountType type) {
            var user = await _incompleteUserService.GetByIdWithAuthData(id);
            if(user == null) return null;

            UserDTO result;
            switch (type) {
                case AccountType.ACC_TYPE_OWNER:
                    result = await _ownerService.Create(_mapper.Map<IncompleteUser, OwnerCreateDTO>(user));
                    break;
                case AccountType.ACC_TYPE_SITTER:
                    result = await _sitterService.Create(_mapper.Map<IncompleteUser, SitterCreateDTO>(user));
                    break;
                default:
                    return null;
            }

            await _incompleteUserService.Delete(user.Id);

            return result;
        }
    }
}
