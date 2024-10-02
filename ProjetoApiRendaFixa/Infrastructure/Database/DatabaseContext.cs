using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.Models;

namespace ProjetoApiRendaFixa.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; } // Adicionar o DbSet para Purchase

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Account)
                .WithMany(a => a.Purchases)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
