using AutoMapper;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class GenericUserService<Model, ReadDTO, CreateDTO, UpdateDTO, LoginDTO> : BaseService<Model, ReadDTO, CreateDTO, UpdateDTO>, IGenericUserService<Model, ReadDTO, CreateDTO, UpdateDTO, LoginDTO> {
        private readonly IGenericUserRepository<Model> _repository;
        public GenericUserService(IGenericUserRepository<Model> repository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
        }

        public async Task<ReadDTO> GetByLogin(LoginDTO model) {
            var mappedModel = _mapper.Map<LoginDTO, Model>(model);
            return _mapper.Map<Model, ReadDTO>(await _repository.GetByLogin(mappedModel));
        }

        public async Task<ReadDTO> GetByUsername(string username) {
            return _mapper.Map<Model, ReadDTO>(await _repository.GetByUsername(username));
        }
    }
}
