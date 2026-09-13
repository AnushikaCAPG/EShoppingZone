using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs;

public class CreateProductDto
{
    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(1, 1000000)]
    public decimal Price { get; set; }

    [Range(1, 10000)]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
}
