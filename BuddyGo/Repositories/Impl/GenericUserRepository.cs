using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class GenericUserRepository<T> : BaseRepository<T>, IGenericUserRepository<T> where T : User {
        public GenericUserRepository(ApplicationDbContext dbContext, DbSet<T> dbSet) : base(dbContext, dbSet) {
        }

        public async Task<T> GetByLogin(T model) {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var byLogin = await _dbSet
                .Include(o => o.AuthData)
                .FirstOrDefaultAsync(o => 
                    o.AuthData.Username.Equals(model.AuthData.Username) && 
                    o.AuthData.Password.Equals(model.AuthData.Password)
                );

            return byLogin;
        }

        public async Task<T> GetByUsername(string username) {
            return await _dbSet.FirstOrDefaultAsync(x => x.AuthData.Username.Equals(username));
        }
    }
}
