using BuddyGo.DTOs.Sitter;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface ISitterService : IGenericUserService<Sitter, SitterDTO, SitterCreateDTO, SitterUpdateDTO, SitterLoginDTO> {
    }
}
