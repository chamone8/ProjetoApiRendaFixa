using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Command
{
    public interface IAccountCommandService
    {
        Task CreateAccount(Account account);
    }
}
