using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;
using BuddyGo.DTOs.Pet;

namespace BuddyGo.Controllers {
    [ApiController]
    [Route("/pets")]
    public class PetController : Controller {
        private readonly IPetService _petService;
        public PetController(IPetService petService) {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult GetAllPets() {
            return Ok(_petService.GetAllPets());
        }

        [HttpGet("{id}", Name = "GetPetById")]
        public async Task<IActionResult> GetPetById(string id) {
            var pet = await _petService.GetPetById(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(PetCreateDTO petCreateDTO) {
            var pet = await _petService.CreatePet(petCreateDTO);
            return CreatedAtRoute(nameof(GetPetById), new { pet.Id }, pet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(string id) {
            var res = await _petService.DeletePet(id);
            if (!res) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(string id, PetUpdateDTO petUpdateDTO) {
            var res = await _petService.UpdatePet(id, petUpdateDTO);
            if (!res) return NotFound();
            return NoContent();
        }
    }
}
