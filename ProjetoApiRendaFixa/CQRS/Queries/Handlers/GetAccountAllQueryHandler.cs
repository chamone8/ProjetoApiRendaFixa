using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Queries.Handlers
{
    public class GetAccountAllQueryHandler
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountAllQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IList<Account>> Handle()
        {
            var account = await _accountRepository.GetAccountAll();
            return account;
        }
    }
}
