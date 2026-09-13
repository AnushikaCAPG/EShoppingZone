using CartService.DTOs;
using CartService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(
        AddToCartDto dto)
    {
        var result =
            await _cartService.AddToCartAsync(dto);

        return Ok(result);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCart(
        int customerId)
    {
        var result =
            await _cartService.GetCartAsync(customerId);

        return Ok(result);
    }

    [HttpDelete("{cartItemId}")]
    public async Task<IActionResult> RemoveItem(
        int cartItemId)
    {
        var result =
            await _cartService.RemoveItemAsync(cartItemId);

        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("clear/{customerId}")]
    public async Task<IActionResult> ClearCart(
        int customerId)
    {
        var result =
            await _cartService.ClearCartAsync(customerId);

        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
}
