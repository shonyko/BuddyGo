﻿using AutoMapper;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.DTOs.Owner;
using BuddyGo.DTOs.User;

namespace BuddyGo.Services.Impl {
    public class AccountFacade : IAccountFacade {
        private readonly IIncompleteUserService _incompleteUserService;
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public AccountFacade(IIncompleteUserService incompleteUserService, IOwnerService ownerService, IMapper mapper) {
            _incompleteUserService = incompleteUserService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByLogin(UserLoginDTO user) {
            var incompleteUser = await _incompleteUserService.GetByLogin(_mapper.Map<IncompleteUserLoginDTO>(user));
            if (incompleteUser != null) return incompleteUser;

            var owner = await _ownerService.GetByLogin(_mapper.Map<OwnerLoginDTO>(user));
            if(owner != null) return owner;

            return null;
        }

        private async Task<UserDTO> GetByUsername(UserLoginDTO user) {
            var username = user.AuthData.Username;
            var incompleteUser = await _incompleteUserService.GetByUsername(username);
            if (incompleteUser != null) return incompleteUser;

            var owner = await _ownerService.GetByUsername(username);
            if (owner != null) return owner;

            return null;
        }

        public async Task<IncompleteUserDTO> Register(UserCreateDTO createDTO) {
            var user = await GetByUsername(_mapper.Map<UserCreateDTO, UserLoginDTO>(createDTO));
            if (user != null) return null;
            return await _incompleteUserService.Create(_mapper.Map<UserCreateDTO, IncompleteUserCreateDTO>(createDTO));
        } 
    }
}
