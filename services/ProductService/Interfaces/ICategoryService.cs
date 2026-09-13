using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Interfaces;

public interface ICategoryService
{
    Task<Category?> CreateCategoryAsync(
        CreateCategoryDto categoryDto);

    Task<List<Category>> GetAllCategoriesAsync();
}
