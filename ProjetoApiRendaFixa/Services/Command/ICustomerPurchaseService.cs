using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Command
{
    public interface ICustomerPurchaseService
    {
        Task AddPurchaseAsync(Purchase purchase);
    }
}
