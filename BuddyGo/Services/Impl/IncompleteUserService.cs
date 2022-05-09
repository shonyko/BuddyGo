using AutoMapper;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class IncompleteUserService : GenericUserService<IncompleteUser, IncompleteUserDTO, IncompleteUserCreateDTO, IncompleteUserUpdateDTO, IncompleteUserLoginDTO>, IIncompleteUserService {
        private readonly IIncompleteUserRepository _repository;
        //private readonly IMapper _mapper;

        public IncompleteUserService(IIncompleteUserRepository repository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
            //_mapper = mapper;
        }

        //public async Task<IncompleteUserDTO> GetByLogin(IncompleteUserLoginDTO loginDTO) {
        //    var mappedUser = _mapper.Map<IncompleteUser>(loginDTO);
        //    var byLogin = await _repository.GetByLogin(mappedUser);
        //    return _mapper.Map<IncompleteUserDTO>(byLogin);
        //}

        ////public async Task<IncompleteUserDTO> Create(IncompleteUserCreateDTO user) {
        ////    var mappedUser  = _mapper.Map<IncompleteUser>(user);
        ////    await _repository.Create(mappedUser);
        ////    return _mapper.Map<IncompleteUserDTO>(mappedUser);
        ////}

        ////public async Task<bool> Delete(string id) {
        ////    var user = await _repository.GetById(id);
        ////    if(user == null) return false;

        ////    await _repository.Delete(user);
        ////    return true;
        ////}

        ////public IEnumerable<IncompleteUserDTO> GetAll() {
        ////    var users = _repository.GetAll();
        ////    return _mapper.Map<List<IncompleteUserDTO>>(users);
        ////}

        ////public async Task<IncompleteUserDTO> GetById(string id) {
        ////    var user = await _repository.GetById(id);
        ////    return _mapper.Map<IncompleteUserDTO>(user);
        ////}

        ////public async Task<bool> Update(string id, IncompleteUserUpdateDTO user) {
        ////    var fromRepo = await _repository.GetById(id);
        ////    if(fromRepo == null) return false;
        ////    _mapper.Map(user, fromRepo);
        ////    await _repository.Update(fromRepo);
        ////    return true;
        ////}
    }
}
