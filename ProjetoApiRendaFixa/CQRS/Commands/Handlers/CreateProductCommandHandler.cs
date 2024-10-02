using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Data.UnitOfWork;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Commands.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Product> Handle(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                return product;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
