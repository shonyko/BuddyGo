using AutoMapper;
using BuddyGo.DTOs.User;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class AuthDataMap : Profile {
        public AuthDataMap() {
            CreateMap<AuthData, AuthDataDTO>();
            CreateMap<AuthDataDTO, AuthData>();
        }
    }
}
