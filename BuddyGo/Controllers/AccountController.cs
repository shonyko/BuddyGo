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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO) {
            var user = await _accountFacade.GetByLogin(loginDTO);
            if (user == null) return NotFound();
            Console.WriteLine(user);
            return Ok(user);
        }
    }
}
