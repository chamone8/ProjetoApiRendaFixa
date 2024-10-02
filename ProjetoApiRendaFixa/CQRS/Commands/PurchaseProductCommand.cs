namespace ProjetoApiRendaFixa.CQRS.Commands
{
    public class PurchaseProductCommand
    {
        public Guid ProductId { get; set; }
        public Guid AccountId { get; set; }
        public int Quantity { get; set; }
    }
}
