namespace BuddyGo.Repositories {
    public interface IRepository<T> {
        public Task Create(T model);

        public IEnumerable<T> GetAll();
        public Task<T> GetById(string id);

        public Task Update(T model);

        public Task Delete(T model);
    }
}
