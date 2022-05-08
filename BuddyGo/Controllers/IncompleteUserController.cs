using BuddyGo.DTOs.IncompleteUser;
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGo.Controllers {
    [ApiController]
    [Route("/iusers")]
    public class IncompleteUserController : Controller {
        private readonly IIncompleteUserService _incompleteUserService;

        public IncompleteUserController(IIncompleteUserService incompleteUserService) {
            _incompleteUserService = incompleteUserService;
        }

        [HttpGet]
        public IActionResult GetAllIUsers() {
            return Ok(_incompleteUserService.GetAll());
        }

        [HttpGet("{id}", Name = "GetIUserById")]
        public async Task<IActionResult> GetIUserById(string id) {
            var iuser = await _incompleteUserService.GetById(id);
            if (iuser == null) return NotFound();
            return Ok(iuser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIUser(IncompleteUserCreateDTO createDTO) {
            var iuser = await _incompleteUserService.Create(createDTO);
            return CreatedAtRoute(nameof(GetIUserById), new { iuser.Id }, iuser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string id) {
            var res = await _incompleteUserService.Delete(id);
            if (!res) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(string id, IncompleteUserUpdateDTO ownerUpdateDTO) {
            var res = await _incompleteUserService.Update(id, ownerUpdateDTO);
            if (!res) return NotFound();
            return NoContent();
        }
    }
}
