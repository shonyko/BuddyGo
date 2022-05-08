using AutoMapper;
using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class IncompleteUserMap : Profile {
        public IncompleteUserMap() {
            CreateMap<IncompleteUser, IncompleteUserDTO>();
            CreateMap<IncompleteUserCreateDTO, IncompleteUser>();
            CreateMap<IncompleteUserUpdateDTO, IncompleteUser>();
            CreateMap<IncompleteUserLoginDTO, IncompleteUser>();
        }
    }
}
