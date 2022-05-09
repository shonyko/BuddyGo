using BuddyGo.DTOs;
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGo.Controllers {
    [ApiController]
    public class BaseController<Model, ReadDTO, CreateDTO, UpdateDTO> : Controller where ReadDTO : BaseDTO{
        private readonly IService<Model, ReadDTO, CreateDTO, UpdateDTO> _service;

        public BaseController(IService<Model, ReadDTO, CreateDTO, UpdateDTO> service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) {
            var model = await _service.GetById(id);
            if (model == null) return NotFound();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIUser(CreateDTO createDTO) {
            var model = await _service.Create(createDTO);
            return CreatedAtAction(nameof(GetById), this.GetType().FullName, new { model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string id) {
            var res = await _service.Delete(id);
            if (!res) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(string id, UpdateDTO ownerUpdateDTO) {
            var res = await _service.Update(id, ownerUpdateDTO);
            if (!res) return NotFound();
            return NoContent();
        }
    }
}
