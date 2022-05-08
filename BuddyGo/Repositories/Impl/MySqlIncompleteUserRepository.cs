using BuddyGo.Data;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class MySqlIncompleteUserRepository : BaseRepository<IncompleteUser>, IIncompleteUserRepository {
        public MySqlIncompleteUserRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.IncompleteUsers) {
        }

        public async Task<IncompleteUser> GetByLogin(IncompleteUser loginDTO) {
            if (loginDTO == null) throw new ArgumentNullException(nameof(loginDTO));
            var byLogin = await _dbSet
                .FirstOrDefaultAsync(o => o.AuthData.Username.Equals(loginDTO.AuthData.Username) && o.AuthData.Password.Equals(loginDTO.AuthData.Password));
            return byLogin;
        }
    }
}
