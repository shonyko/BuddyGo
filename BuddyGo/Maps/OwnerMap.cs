using AutoMapper;
using BuddyGo.DTOs.Owner;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class OwnerMap : Profile {
        public OwnerMap() {
            CreateMap<Owner, OwnerDTO>();
            CreateMap<OwnerCreateDTO, Owner>();
            CreateMap<OwnerUpdateDTO, Owner>();
            CreateMap<OwnerLoginDTO, Owner>();
        }
    }
}
