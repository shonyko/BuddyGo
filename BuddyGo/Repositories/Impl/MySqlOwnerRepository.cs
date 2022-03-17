using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class MySqlOwnerRepository : IOwnerRepository {
        private readonly ApplicationDbContext _dbContext;
        public MySqlOwnerRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task CreateOwner(Owner owner) {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            _dbContext.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Owner> GetOwnerById(string id) {
            var owner = await _dbContext.Owners.Where(o => o.Id == id).Include(o => o.Pets).FirstOrDefaultAsync();
            return owner;
        }

        public IEnumerable<Owner> GetAllOwners() {
            var owners = _dbContext.Owners.ToList();
            return owners;
        }

        public async Task UpdateOwner(Owner owner) {
            _dbContext.Entry(await GetOwnerById(owner.Id)).CurrentValues.SetValues(owner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOwner(Owner owner) {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            _dbContext.Owners.Remove(owner);
            await _dbContext.SaveChangesAsync();
        }
    }
}
