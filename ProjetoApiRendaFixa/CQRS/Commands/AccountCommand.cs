namespace ProjetoApiRendaFixa.CQRS.Commands
{
    public class AccountCommand
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }

        public AccountCommand(string accountName, decimal balance)
        {
            AccountName = accountName;
            Balance = balance;
        }
    }    
}