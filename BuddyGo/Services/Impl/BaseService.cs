using AutoMapper;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class BaseService<Model, ReadDTO, CreateDTO, UpdateDTO> : IService<Model, ReadDTO, CreateDTO, UpdateDTO> {
        private readonly IRepository<Model> _repository;
        protected readonly IMapper _mapper;
        
        public BaseService(IRepository<Model> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadDTO> Create(CreateDTO model) {
            var mappedModel = _mapper.Map<Model>(model);
            await _repository.Create(mappedModel);
            return _mapper.Map<ReadDTO>(mappedModel);
        }

        public async Task<bool> Delete(string id) {
            var model = await _repository.GetById(id);
            if (model == null) return false;

            await _repository.Delete(model);
            return true;
        }

        public IEnumerable<ReadDTO> GetAll() {
            var users = _repository.GetAll();
            return _mapper.Map<List<ReadDTO>>(users);
        }

        public async Task<ReadDTO> GetById(string id) {
            var user = await _repository.GetById(id);
            return _mapper.Map<ReadDTO>(user);
        }

        public async Task<bool> Update(string id, UpdateDTO model) {
            var fromRepo = await _repository.GetById(id);
            if (fromRepo == null) return false;
            _mapper.Map(model, fromRepo);
            await _repository.Update(fromRepo);
            return true;
        }
    }
}
