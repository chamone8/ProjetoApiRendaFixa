using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Queries.Handlers
{
    public class GetAccountByIdQueryHandler
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(GetAccountByIdQuery query)
        {
            var account = await _accountRepository.GetAccount(query.AccountId);
            return account;
        }
    }
}
