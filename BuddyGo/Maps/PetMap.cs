using AutoMapper;
using BuddyGo.DTOs.Pet;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class PetMap : Profile {
        public PetMap() {
            CreateMap<Pet, PetDTO>();
            CreateMap<PetCreateDTO, Pet>();
            CreateMap<PetUpdateDTO, Pet>();
        }
    }
}
