using ProjetoApiRendaFixa.Data.Repositories;

namespace ProjetoApiRendaFixa.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Propriedades dos repositórios
        IProductRepository Products { get; }
        IAccountRepository Account { get; }

        // Método para salvar as alterações
        Task<int> SaveChangesAsync();
    }
}
