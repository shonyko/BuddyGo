using AutoMapper;
using BuddyGo.DTOs.Sitter;
using BuddyGo.Models;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class SitterService  : GenericUserService<Sitter, SitterDTO, SitterCreateDTO, SitterUpdateDTO, SitterLoginDTO>, ISitterService {
        private readonly ISitterRepository _repository;

        public SitterService(ISitterRepository repository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
        }
    }
}
