using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface IIncompleteUserService : IService<IncompleteUser, IncompleteUserDTO, IncompleteUserCreateDTO, IncompleteUserUpdateDTO> {
        public Task<IncompleteUserDTO> GetByLogin(IncompleteUserLoginDTO loginDTO);
    }
}
