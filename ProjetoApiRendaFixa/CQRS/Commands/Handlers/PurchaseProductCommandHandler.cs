using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Data.UnitOfWork;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Commands.Handlers
{
    public class PurchaseProductCommandHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerPurchaseRepository _customerPurchaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public PurchaseProductCommandHandler(IProductRepository productRepository, ICustomerPurchaseRepository customerPurchaseRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _productRepository = productRepository;
            _customerPurchaseRepository = customerPurchaseRepository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public async Task Handle(PurchaseProductCommand command)
        {
            try
            {
                var product = await _productRepository.GetById(command.ProductId);
                var account = await _accountRepository.GetAccount(command.AccountId);
               
                if (product == null)
                    throw new Exception("Produto não encontrado.");

                if (product.Stock < command.Quantity)
                    throw new Exception("Estoque insuficiente.");
                
                if((product.UnitPrice * command.Quantity)  > account.Balance)
                    throw new Exception("Saldo Insuficiente.");
                
                product.Stock -= command.Quantity;
                account.Balance -= (command.Quantity * product.UnitPrice);

                var customerPurchase = new Purchase
                {
                    Id = Guid.NewGuid(),
                    AccountId = command.AccountId,
                    ProductId = command.ProductId,
                    PurchaseDate = DateTime.UtcNow,
                    Quantity = command.Quantity,
                    TotalPrice = product.UnitPrice * command.Quantity
                };

                _productRepository.Update(product);
                await _customerPurchaseRepository.AddPurchaseAsync(customerPurchase);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao comprar o produto: {ex.Message}");
            }
        }
    }
}