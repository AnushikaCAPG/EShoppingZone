namespace AuthService.Models;

public class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = string.Empty;

    public string GatewayReference { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public Order? Order { get; set; }
}