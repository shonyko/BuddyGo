using AutoMapper;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.DTOs.Owner;
using BuddyGo.DTOs.User;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class UserMap : Profile {
        public UserMap() {
            CreateMap<User, UserDTO>();
            CreateMap<UserLoginDTO, IncompleteUserLoginDTO>();
            CreateMap<UserLoginDTO, OwnerLoginDTO>();
        }
    }
}
