using ProjetoApiRendaFixa.CQRS.Commands;
using ProjetoApiRendaFixa.CQRS.Commands.Handlers;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Services.Command
{
    public interface IProductCommandService
    {
        Task PurchaseProduct(Purchase request);
        Task<Product> CreateProduct(CreateProductCommand request);
    }
}
