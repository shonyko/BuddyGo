using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.DTOs.User;
using BuddyGo.Enums;

namespace BuddyGo.Services {
    public interface IAccountFacade {
        public Task<UserDTO> GetByLogin(UserLoginDTO user);
        public Task<IncompleteUserDTO> Register(UserCreateDTO user);
        public Task<UserDTO> SetType(string id, AccountType type);
    }
}
