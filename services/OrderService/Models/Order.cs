namespace OrderService.Models;

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = "Placed";

    public DateTime CreatedDate { get; set; }
        = DateTime.UtcNow;
}