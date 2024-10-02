using ProjetoApiRendaFixa.CQRS.Queries.Handlers;
using ProjetoApiRendaFixa.CQRS.Queries;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Query
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly GetProductsQueryHandler _getProductsQueryHandler;

        public ProductQueryService(IProductRepository productRepository)
        {
            _getProductsQueryHandler = new GetProductsQueryHandler(productRepository);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var query = new GetProductsQuery();
            var products = await _getProductsQueryHandler.Handle(query);
            return products.ToList();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var query = new GetProductsQuery() { IdProduct = id };
            var products = await _getProductsQueryHandler.Handle(query);

            return products.FirstOrDefault();
        }
    }
}
