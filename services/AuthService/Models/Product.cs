namespace AuthService.Models;

public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public int MerchantId { get; set; }

    public bool IsActive { get; set; } = true;

    public Category? Category { get; set; }

    public Merchant? Merchant { get; set; }
}