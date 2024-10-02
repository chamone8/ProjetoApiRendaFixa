using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public interface ICustomerPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesByCustomer(Guid customerId);
        Task AddPurchaseAsync(Purchase purchase);
    }
}
