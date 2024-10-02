using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{
    public interface IPurchaseQueryService
    {
        Task<IEnumerable<Purchase>> GetCustomerPurchasesAsync(Guid customerId);

    }
}
