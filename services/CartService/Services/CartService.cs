using CartService.Data;
using CartService.DTOs;
using CartService.Interfaces;
using CartService.Models;
using Microsoft.EntityFrameworkCore;

namespace CartService.Services;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddToCartAsync(AddToCartDto dto)
    {
        var cart = await _context.Carts
            .FirstOrDefaultAsync(x =>
                x.CustomerId == dto.CustomerId);

        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = dto.CustomerId,
                TotalAmount = 0
            };

            _context.Carts.Add(cart);

            await _context.SaveChangesAsync();
        }

        var cartItem = new CartItem
        {
            CartId = cart.CartId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice,
            SubTotal = dto.Quantity * dto.UnitPrice
        };

        _context.CartItems.Add(cartItem);

        cart.TotalAmount += cartItem.SubTotal;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CartResponseDto>> GetCartAsync(
        int customerId)
    {
        var cart = await _context.Carts
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);

        if (cart == null)
        {
            return new List<CartResponseDto>();
        }

        return await _context.CartItems
            .Where(x => x.CartId == cart.CartId)
            .Select(x => new CartResponseDto
            {
                CartItemId = x.CartItemId,
                ProductName = $"Product-{x.ProductId}",
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                SubTotal = x.SubTotal
            })
            .ToListAsync();
    }

    public async Task<bool> RemoveItemAsync(int cartItemId)
    {
        var item = await _context.CartItems
            .FirstOrDefaultAsync(
                x => x.CartItemId == cartItemId);

        if (item == null)
        {
            return false;
        }

        _context.CartItems.Remove(item);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ClearCartAsync(int customerId)
    {
        var cart = await _context.Carts
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);

        if (cart == null)
        {
            return false;
        }

        var items = await _context.CartItems
            .Where(x => x.CartId == cart.CartId)
            .ToListAsync();

        _context.CartItems.RemoveRange(items);

        cart.TotalAmount = 0;

        await _context.SaveChangesAsync();

        return true;
    }
}
