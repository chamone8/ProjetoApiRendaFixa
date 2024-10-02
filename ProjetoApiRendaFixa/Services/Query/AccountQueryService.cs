using ProjetoApiRendaFixa.CQRS.Queries;
using ProjetoApiRendaFixa.CQRS.Queries.Handlers;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{

    public class AccountQueryService : IAccountQueryService
    {
        private readonly GetAccountAllQueryHandler _getAccountAllQueryHandler;
        private readonly GetAccountByIdQueryHandler _getAccountByIdQuery;

        public AccountQueryService(GetAccountAllQueryHandler getAccountAllQueryHandler1, GetAccountByIdQueryHandler getAccountByIdQuery)
        {
            _getAccountAllQueryHandler = getAccountAllQueryHandler1;
            _getAccountByIdQuery = getAccountByIdQuery;
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            var query = new GetAccountByIdQuery(id);
            return await _getAccountByIdQuery.Handle(query);
        }
        public async Task<IList<Account>> GetAccountAll()
        {
            return await _getAccountAllQueryHandler.Handle();
        }

       
    }
}
