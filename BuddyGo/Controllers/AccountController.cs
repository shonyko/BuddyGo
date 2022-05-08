using BuddyGo.DTOs.User;
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

        // TODO: De reparat CreatedAtRoute
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDTO createDTO) {
            var user = await _accountFacade.Register(createDTO);
            if(user == null) return Conflict();
            return CreatedAtRoute(nameof(Login), new { user.Id }, user);
        }
    }
}
