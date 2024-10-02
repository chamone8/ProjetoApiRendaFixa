using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{
    public interface IProductQueryService
    {
        Task<List<Product>> GetAllProductsAsync(); 
        Task<Product> GetProductByIdAsync(Guid id);
    }
}
