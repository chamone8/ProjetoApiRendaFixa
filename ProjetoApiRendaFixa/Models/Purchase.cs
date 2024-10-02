using Newtonsoft.Json;

namespace ProjetoApiRendaFixa.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; } 
        public Guid ProductId { get; set; }  
        public DateTime PurchaseDate { get; set; }  
        public int Quantity { get; set; }  
        public decimal TotalPrice { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
