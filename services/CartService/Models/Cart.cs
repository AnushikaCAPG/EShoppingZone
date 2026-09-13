namespace CartService.Models;

public class Cart
{
    public int CartId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }
}