using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Command
{
    public class CustomerPurchaseService : ICustomerPurchaseService
    {

        private readonly ICustomerPurchaseRepository _purchaseRepository;

        public CustomerPurchaseService(ICustomerPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.AddPurchaseAsync(purchase);
        }

    }
}
