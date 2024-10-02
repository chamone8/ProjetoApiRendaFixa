using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Infrastructure.Database;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public class CustomerPurchaseRepository : ICustomerPurchaseRepository
    {
        private readonly DatabaseContext _context;

        public CustomerPurchaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByCustomer(Guid customerId)
        {
            return await _context.Purchases
                .Where(p => p.AccountId == customerId)
                .ToListAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
