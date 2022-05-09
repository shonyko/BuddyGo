namespace BuddyGo.Repositories {
    public interface IGenericUserRepository<T> : IRepository<T> {
        public Task<T> GetByUsername(string username);
        public Task<T> GetByLogin(T model);
        public Task<T> GetByIdWithAuthData(string id);
    }
}
