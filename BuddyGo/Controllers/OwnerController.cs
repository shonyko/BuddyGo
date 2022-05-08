using BuddyGo.DTOs.Owner;
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGo.Controllers {
    [ApiController]
    [Route("/owners")]
    public class OwnerController : Controller {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService) {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult GetAllOwners() { 
            return Ok(_ownerService.GetAllOwners());
        }

        [HttpGet("{id}", Name = "GetOwnerById")]
        public async Task<IActionResult> GetOwnerById(string id) {
            var owner = await _ownerService.GetOwnerById(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerCreateDTO ownerCreateDTO) {
            var owner = await _ownerService.CreateOwner(ownerCreateDTO);
            return CreatedAtRoute(nameof(GetOwnerById), new { owner.Id }, owner);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string id) {
            var res = await _ownerService.DeleteOwner(id);
            if (!res) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(string id, OwnerUpdateDTO ownerUpdateDTO) {
            var res = await _ownerService.UpdateOwner(id, ownerUpdateDTO);
            if (!res) return NotFound();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetOwnerByLogin(OwnerLoginDTO ownerLoginDTO) {
            var owner = await _ownerService.GetOwnerByLogin(ownerLoginDTO);
            if (owner == null) return NotFound();
            Console.WriteLine(owner);
            return Ok(owner);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(OwnerCreateDTO ownerCreateDTO) => await CreateOwner(ownerCreateDTO);
    }
}
