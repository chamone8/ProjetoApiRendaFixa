using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(Guid id);
        Task<IList<Account>> GetAccountAll();
        void Update(Account account);
        void Create(Account account);
    }
}
