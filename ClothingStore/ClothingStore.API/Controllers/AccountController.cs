using ClothingStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetAccountByName(string UserName)
        {
            var result = await _accountService.GetAccountByNameAsync(UserName);
            return Ok(result);
        }
    }
}
