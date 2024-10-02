using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Infrastructure.Database;
using ProjetoApiRendaFixa.Models;
using System.Collections.Generic;

namespace ProjetoApiRendaFixa.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
        }


        public async Task<IList<Account>> GetAccountAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public async Task<Account> GetAccount(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _context.Accounts
                                     .SingleOrDefaultAsync(p => p.Id == id);
            }
            return null;
        }
    }

}
