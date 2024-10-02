using System.Text.Json.Serialization;

namespace ProjetoApiRendaFixa.Models
{
    public class Account
    {
        public Account(string name, decimal balance)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = balance;
        }

        public IList<Purchase> Purchases { get; set; } = new List<Purchase>();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; } //Saldo
    }
}