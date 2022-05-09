using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class MySqlSitterRepository : GenericUserRepository<Sitter>, ISitterRepository {
        public MySqlSitterRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Sitters) {
        }
    }
}
