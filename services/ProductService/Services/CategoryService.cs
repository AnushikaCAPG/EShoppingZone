using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTOs;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> CreateCategoryAsync(
        CreateCategoryDto categoryDto)
    {
        var existingCategory =
            await _context.Categories
                .FirstOrDefaultAsync(c =>
                    c.CategoryName.ToLower() ==
                    categoryDto.CategoryName.ToLower());

        if (existingCategory != null)
        {
            return null;
        }

        var category = new Category
        {
            CategoryName = categoryDto.CategoryName
        };

        _context.Categories.Add(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}