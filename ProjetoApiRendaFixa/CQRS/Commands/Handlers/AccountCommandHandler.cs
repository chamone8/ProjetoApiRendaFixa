using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Data.UnitOfWork;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.CQRS.Commands.Handlers
{
    public class AccountCommandHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Account account)
        {
            try
            {

                _accountRepository.Create(account);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}