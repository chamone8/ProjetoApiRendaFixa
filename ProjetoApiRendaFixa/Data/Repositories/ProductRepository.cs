using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Infrastructure.Database;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllOrderedByRate()
        {
            var products = await _context.Products.ToListAsync();
            return products.OrderBy(p => p.Tax).ToList();

        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }


        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
