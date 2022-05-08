namespace BuddyGo.Services {
    public interface IService<Model, ReadDTO, CreateDTO, UpdateDTO> {
        public Task<ReadDTO> Create(CreateDTO model);

        public Task<ReadDTO> GetById(string id);

        public IEnumerable<ReadDTO> GetAll();
        public Task<bool> Update(string id, UpdateDTO model);

        public Task<bool> Delete(string id);
    }
}
