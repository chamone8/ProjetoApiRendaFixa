namespace ProjetoApiRendaFixa.CQRS.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Taxa { get; set; }
        public int Ballast { get; set; }
        public string BondAsset { get; set; }
        public string Index { get; set; }

        // Construtor padrão é opcional se você usar propriedades auto-implementadas
        public CreateProductCommand() { }

        // Se você quiser um construtor com parâmetros
        public CreateProductCommand(string name, decimal price, decimal taxa, int ballast, string bondAsset, string index)
        {
            Name = name;
            Price = price;
            Taxa = taxa;
            Ballast = ballast;
            BondAsset = bondAsset;
            Index = index;
        }
    }
}
