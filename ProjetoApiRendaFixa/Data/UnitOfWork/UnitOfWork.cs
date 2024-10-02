using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Infrastructure.Database;

namespace ProjetoApiRendaFixa.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Products = new ProductRepository(_context);
            AccountToro = new AccountRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IAccountRepository AccountToro { get; private set; }

        public IAccountRepository Account => throw new NotImplementedException();

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Tratar exceções de atualização do banco de dados, se necessário
                throw new Exception("Erro ao salvar as alterações no banco de dados.", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
