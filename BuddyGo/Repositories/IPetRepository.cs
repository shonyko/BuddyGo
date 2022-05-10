using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IPetRepository : IRepository<Pet> {
        //public Task Create(Pet pet);

        //public Task<Pet> GetById(string id);

        //public IEnumerable<Pet> GetAll();
        //public Task Update(Pet pet);

        //public Task Delete(Pet pet);
        public Task<List<Pet>> GetAllByOwnerId(string id);
    }
}
