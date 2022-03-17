using AutoMapper;
using BuddyGo.DTOs.User;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class UserMap : Profile {
        public UserMap() {
            CreateMap<User, UserDTO>();
        }
    }
}
