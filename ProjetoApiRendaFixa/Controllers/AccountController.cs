using Microsoft.AspNetCore.Mvc;
using ProjetoApiRendaFixa.Models;
using ProjetoApiRendaFixa.Services.Command;
using ProjetoApiRendaFixa.Services.Query;

namespace ProjetoApiRendaFixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountCommandService _accountCommandService;
        private readonly IAccountQueryService _accountQueryService;

        public AccountController(IAccountCommandService accountCommandService, IAccountQueryService accountQueryService)
        {
            _accountCommandService = accountCommandService;
            _accountQueryService = accountQueryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await _accountQueryService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAccountAll()
        {
            var account = await _accountQueryService.GetAccountAll();
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(string name, int balance)
        {
            var account = new Account(name, balance);
            await _accountCommandService.CreateAccount(account);
            return Ok();
        }
    }
}