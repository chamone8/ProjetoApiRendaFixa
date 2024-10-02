using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Queries.Handlers
{
    public class GetProductsQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query)
        {
            if (query.IdProduct != Guid.Empty)
            {
                var produto = await _productRepository.GetById(query.IdProduct);
                return produto != null ? new[] { produto } : Enumerable.Empty<Product>();
            }
            else
            {
                var produtos = await _productRepository.GetAllOrderedByRate();
                return produtos;
            }
        }
    }
}
