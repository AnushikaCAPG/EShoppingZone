using System.ComponentModel.DataAnnotations;

namespace CartService.DTOs;

public class AddToCartDto
{
    [Range(1, int.MaxValue)]
    public int CustomerId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Range(1, 100)]
    public int Quantity { get; set; }

    [Range(1, 1000000)]
    public decimal UnitPrice { get; set; }
}
