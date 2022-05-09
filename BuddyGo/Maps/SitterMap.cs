using AutoMapper;
using BuddyGo.DTOs.Sitter;
using BuddyGo.Models;

namespace BuddyGo.Maps {
    public class SitterMap : Profile {
        public SitterMap() {
            CreateMap<Sitter, SitterDTO>();
            CreateMap<SitterCreateDTO, Sitter>();
            CreateMap<SitterUpdateDTO, Sitter>();
            CreateMap<SitterLoginDTO, Sitter>();
        }
    }
}
