namespace BuddyGo.Repositories {
    public interface IRepository<T> {
        public Task Create(T model);

        public Task<T> GetById(string id);

        public IEnumerable<T> GetAll();
        public Task Update(T model);

        public Task Delete(T model);
    }
}
