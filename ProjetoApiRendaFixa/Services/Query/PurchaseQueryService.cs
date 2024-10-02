using ProjetoApiRendaFixa.CQRS.Queries.Handlers;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{
    public class PurchaseQueryService : IPurchaseQueryService
    {
        private readonly GetAllPurchasesByAccountHandler _getAllPurchasesByAccountHandler;

        public PurchaseQueryService(GetAllPurchasesByAccountHandler getAllPurchasesByAccountHandler)
        {
            _getAllPurchasesByAccountHandler = getAllPurchasesByAccountHandler;
        }

        public async Task<IEnumerable<Purchase>> GetCustomerPurchasesAsync(Guid customerId)
        {
            return await _getAllPurchasesByAccountHandler.GetAllPurchasesByCustomer(customerId);
        }

    }
}
