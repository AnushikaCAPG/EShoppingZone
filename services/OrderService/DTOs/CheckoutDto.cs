using System.ComponentModel.DataAnnotations;

namespace OrderService.DTOs;

public class CheckoutDto
{
    [Range(1, int.MaxValue)]
    public int CustomerId { get; set; }
}
