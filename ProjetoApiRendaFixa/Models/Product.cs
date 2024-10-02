namespace ProjetoApiRendaFixa.Models
{
    public class Product
    {
        public Product(string bondAsset, string index, string issuerName, decimal unitPrice, decimal tax, int stock)
        {
            Id = Guid.NewGuid();
            BondAsset = bondAsset;
            Index = index;
            IssuerName = issuerName;
            UnitPrice = unitPrice;
            Tax = tax;
            Stock = stock;
        }

        public Guid Id { get; set; } = new Guid();
        public string BondAsset { get; set; }
        public string Index { get; set; }
        public string IssuerName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public int Stock { get; set; } 
    }


}
