using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class MySqlIncompleteUserRepository : BaseRepository<IncompleteUser> {
        private readonly ApplicationDbContext _dbContext;
        public MySqlIncompleteUserRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.IncompleteUsers) {
            _dbContext = dbContext;
        }
    }
}
