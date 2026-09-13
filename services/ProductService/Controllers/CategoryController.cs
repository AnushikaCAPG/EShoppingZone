using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Interfaces;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(
        ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
public async Task<IActionResult> CreateCategory(
    CreateCategoryDto dto)
{
    var result =
        await _categoryService.CreateCategoryAsync(dto);

    if (result == null)
    {
        return BadRequest("Category already exists.");
    }

    return Ok(result);
}

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result =
            await _categoryService
                .GetAllCategoriesAsync();

        return Ok(result);
    }
}