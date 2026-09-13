using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Interfaces;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        CreateProductDto dto)
    {
        var result =
            await _productService.CreateProductAsync(dto);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result =
            await _productService.GetAllProductsAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result =
            await _productService.GetProductByIdAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(
        int id,
        UpdateProductDto dto)
    {
        var result =
            await _productService.UpdateProductAsync(id, dto);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result =
            await _productService.DeleteProductAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
}
