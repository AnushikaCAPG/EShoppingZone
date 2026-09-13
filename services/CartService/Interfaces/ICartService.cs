using CartService.DTOs;

namespace CartService.Interfaces;

public interface ICartService
{
    Task<bool> AddToCartAsync(AddToCartDto dto);

    Task<List<CartResponseDto>> GetCartAsync(int customerId);

    Task<bool> RemoveItemAsync(int cartItemId);

    Task<bool> ClearCartAsync(int customerId);
}
