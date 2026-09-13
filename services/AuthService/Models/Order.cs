namespace AuthService.Models;

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public int PaymentModeId { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = string.Empty;


    public string PaymentStatus { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public Customer? Customer { get; set; }

    public Address? Address { get; set; }

    public PaymentMode? PaymentMode { get; set; }
}