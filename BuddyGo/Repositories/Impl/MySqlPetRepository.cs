using BuddyGo.Data;
using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public class MySqlPetRepository : IPetRepository {
        private readonly ApplicationDbContext _dbContext;
        public MySqlPetRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task CreatePet(Pet pet) {
            if (pet == null) throw new ArgumentNullException(nameof(pet));
            _dbContext.Pets.Add(pet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePet(Pet pet) {
            if (pet == null) throw new ArgumentNullException(nameof(pet));
            _dbContext.Pets.Remove(pet);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Pet> GetAllPets() => _dbContext.Pets.ToList();

        public async Task<Pet> GetPetById(string id) => await _dbContext.Pets.FindAsync(id);

        public async Task UpdatePet(Pet pet) {
            _dbContext.Entry(await GetPetById(pet.Id)).CurrentValues.SetValues(pet);
            await _dbContext.SaveChangesAsync();
        }
    }
}
