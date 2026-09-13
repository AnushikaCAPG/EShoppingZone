using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTOs;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProductAsync(
        CreateProductDto productDto)
    {
        var product = new Product
        {
            ProductName = productDto.ProductName,
            Description = productDto.Description,
            Price = productDto.Price,
            Quantity = productDto.Quantity,
            CategoryId = productDto.CategoryId,
            MerchantId = 1,
            IsActive = true
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Product?> UpdateProductAsync(
        int id,
        UpdateProductDto dto)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
        {
            return null;
        }

        product.ProductName = dto.ProductName;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Quantity = dto.Quantity;
        product.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();

        return product;
    }
}
