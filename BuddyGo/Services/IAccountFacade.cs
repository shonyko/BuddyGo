using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.DTOs.User;

namespace BuddyGo.Services {
    public interface IAccountFacade {
        public Task<UserDTO> GetByLogin(UserLoginDTO user);
        public Task<IncompleteUserDTO> Register(IncompleteUserCreateDTO user);
    }
}
