namespace ProdManager.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime Manufacture { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}