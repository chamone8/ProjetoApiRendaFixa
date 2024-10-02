namespace ProjetoApiRendaFixa.CQRS.Queries
{
    public class GetProductsQuery
    {
        public Guid IdProduct { get; set; }
        public Guid IdAccount { get; set; }
        public int Quantity { get; set; }
    }
}
