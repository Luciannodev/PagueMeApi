using Microsoft.AspNetCore.Mvc;
using PagueMe.Application.Interfaces;

namespace PagueMe.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountUseCase _accountUseCase;

        public AccountController(IAccountUseCase accountUseCase)
        {
            _accountUseCase = accountUseCase;
        }

        [HttpGet("check-password")]
        public IActionResult CheckPassword(string Password)
        {
            bool v = _accountUseCase.PasswordIsValid(Password);
            return Ok(v);
        }
    }
}
