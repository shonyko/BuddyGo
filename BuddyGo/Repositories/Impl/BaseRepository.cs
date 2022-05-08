using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext, DbSet<T> dbSet) {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async Task Create(T model) {
            if(model == null) throw new ArgumentNullException(nameof(model));
            _dbSet.Add(model);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<T> GetById(string id) {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public IEnumerable<T> GetAll() {
            return _dbSet.ToList();
        }
        public async Task Update(T model) {
            _dbContext.Entry(await GetById(model.Id)).CurrentValues.SetValues(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T model) {
            if(model == null) throw new ArgumentNullException(nameof(model));
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
