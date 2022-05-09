using BuddyGo.Data;
using BuddyGo.Models;

namespace BuddyGo.Repositories.Impl {
    public class MySqlIncompleteUserRepository : GenericUserRepository<IncompleteUser>, IIncompleteUserRepository {
        public MySqlIncompleteUserRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.IncompleteUsers) {
        }
    }
}
