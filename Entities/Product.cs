namespace ProdManager.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CodeBar { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Lot { get; set; } = string.Empty;
        public DateTime Manufacture { get; set; }
        public DateTime Expiration { get; set; }
    }
}
