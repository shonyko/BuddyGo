namespace BuddyGo.Services {
    public interface IGenericUserService<Model, ReadDTO, CreateDTO, UpdateDTO, LoginDTO> : IService<Model, ReadDTO, CreateDTO, UpdateDTO> {
        public Task<ReadDTO> GetByUsername(string username);
        public Task<ReadDTO> GetByLogin(LoginDTO model);
        public Task<Model> GetByIdWithAuthData(string id);
    }
}
