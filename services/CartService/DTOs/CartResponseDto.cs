namespace CartService.DTOs;

public class CartResponseDto
{
    public int CartItemId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal SubTotal { get; set; }
}
