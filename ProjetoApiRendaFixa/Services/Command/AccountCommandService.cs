using ProjetoApiRendaFixa.CQRS.Commands;
using ProjetoApiRendaFixa.CQRS.Commands.Handlers;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Command
{
    public class AccountCommandService : IAccountCommandService
    {
        private readonly AccountCommandHandler _accountCommandHandler;

        public AccountCommandService(AccountCommandHandler accountCommandHandler)
        {
            _accountCommandHandler = accountCommandHandler;
        }

        public async Task CreateAccount(Account command)
        {

            var account = new Account(command.Name, command.Balance);
            await _accountCommandHandler.Handle(account);
        }
    }
}
