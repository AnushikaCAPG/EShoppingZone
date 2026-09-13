using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Interfaces;

public interface IProductService
{
    Task<Product> CreateProductAsync(
        CreateProductDto productDto);

    Task<List<Product>> GetAllProductsAsync();

    Task<Product?> GetProductByIdAsync(int id);

    Task<bool> DeleteProductAsync(int id);

    Task<Product?> UpdateProductAsync(
        int id,
        UpdateProductDto dto);
}
