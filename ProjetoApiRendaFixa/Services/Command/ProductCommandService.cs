using ProjetoApiRendaFixa.CQRS.Commands;
using ProjetoApiRendaFixa.CQRS.Commands.Handlers;
using ProjetoApiRendaFixa.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjetoApiRendaFixa.Services.Command
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly PurchaseProductCommandHandler _commandHandler;
        private readonly CreateProductCommandHandler _createProductCommand;

        public ProductCommandService(PurchaseProductCommandHandler commandHandler, CreateProductCommandHandler createProductCommand)
        {
            _commandHandler = commandHandler;
            _createProductCommand = createProductCommand;
        }

        public async Task PurchaseProduct(Purchase request)
        {

            var command = new PurchaseProductCommand
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                AccountId = request.AccountId
            };

            await _commandHandler.Handle(command);
        }
        public async Task<Product> CreateProduct(CreateProductCommand command)
        {
            var product = new Product(
                bondAsset: command.BondAsset,
                index: command.Index,
                issuerName: command.Name,
                unitPrice: command.Price,
                tax: command.Taxa,
                stock: command.Ballast
             );
            return await _createProductCommand.Handle(product);
        }

    }
}
