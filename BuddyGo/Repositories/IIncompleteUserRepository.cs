using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IIncompleteUserRepository : IRepository<IncompleteUser> {
        public Task<IncompleteUser> GetByLogin(IncompleteUser loginDTO);
    }
}
