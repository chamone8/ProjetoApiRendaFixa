using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Queries.Handlers
{
    public class GetAllPurchasesByAccountHandler
    {
        private readonly ICustomerPurchaseRepository _customerPurchaseRepository;

        public GetAllPurchasesByAccountHandler(ICustomerPurchaseRepository customerPurchaseRepository)
        {
            _customerPurchaseRepository = customerPurchaseRepository;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByCustomer(Guid customerId)
        {
            return await _customerPurchaseRepository.GetAllPurchasesByCustomer(customerId);
        }
    }
}
