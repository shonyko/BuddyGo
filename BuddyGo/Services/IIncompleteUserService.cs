using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface IIncompleteUserService : IGenericUserService<IncompleteUser, IncompleteUserDTO, IncompleteUserCreateDTO, IncompleteUserUpdateDTO, IncompleteUserLoginDTO> {
        //public Task<IncompleteUserDTO> GetByLogin(IncompleteUserLoginDTO loginDTO);
    }
}
