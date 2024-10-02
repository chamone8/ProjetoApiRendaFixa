using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllOrderedByRate();
        Task<Product> GetById(Guid id);
        void Update(Product product);
        Task AddAsync(Product product);
    }
}
