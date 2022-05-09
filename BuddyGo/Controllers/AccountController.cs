using BuddyGo.DTOs.User;
using BuddyGo.Enums;
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGo.Controllers {
    [ApiController]
    [Route("/account")]
    public class AccountController : Controller {
        private readonly IAccountFacade _accountFacade;

        public AccountController(IAccountFacade accountFacade) {
            _accountFacade = accountFacade;
        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO) {
            var user = await _accountFacade.GetByLogin(loginDTO);
            if (user == null) return NotFound();
            Console.WriteLine(user);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDTO createDTO) {
            var user = await _accountFacade.Register(createDTO);
            if(user == null) return Conflict();
            return CreatedAtAction("GetById", nameof(IncompleteUserController), new { user.Id }, user);
        }

        [HttpPost("type")]
        public async Task<IActionResult> SetType(UserChangeTypeDTO dto) {
            var res = await _accountFacade.SetType(dto.Id, dto.Type);
            if (res == null) return Forbid();
            return Ok(res);
        }
    }
}
