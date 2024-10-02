using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{
    public interface IAccountQueryService
    {
        Task<Account> GetAccountById(Guid id);
        Task<IList<Account>> GetAccountAll();
    }
}
