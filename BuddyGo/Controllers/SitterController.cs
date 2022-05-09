using BuddyGo.DTOs.Sitter;
using BuddyGo.Models;
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGo.Controllers {
    [Route("/sitters")]
    public class SitterController : BaseController<Sitter, SitterDTO, SitterCreateDTO, SitterUpdateDTO> {
        private readonly ISitterService _sitterService;

        public SitterController(ISitterService sitterService) : base(sitterService) {
            _sitterService = sitterService;
        }
    }
}
