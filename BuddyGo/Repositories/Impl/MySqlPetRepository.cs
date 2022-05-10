using BuddyGo.Data;
using BuddyGo.Models;
using BuddyGo.Repositories.Impl;

namespace BuddyGo.Repositories {
    public class MySqlPetRepository : BaseRepository<Pet>, IPetRepository {
        //private readonly ApplicationDbContext _dbContext;

        public MySqlPetRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Pets) {
            //_dbContext = dbContext;
        }

        public Task<List<Pet>> GetAllByOwnerId(string id) {
            return Task.FromResult(_dbSet.Where(p => p.OwnerId == id).ToList());
        }

        //public async Task Create(Pet pet) {
        //    if (pet == null) throw new ArgumentNullException(nameof(pet));
        //    _dbContext.Pets.Add(pet);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task Delete(Pet pet) {
        //    if (pet == null) throw new ArgumentNullException(nameof(pet));
        //    _dbContext.Pets.Remove(pet);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public IEnumerable<Pet> GetAll() => _dbContext.Pets.ToList();

        //public async Task<Pet> GetById(string id) => await _dbContext.Pets.FindAsync(id);

        //public async Task Update(Pet pet) {
        //    _dbContext.Entry(await GetById(pet.Id)).CurrentValues.SetValues(pet);
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
