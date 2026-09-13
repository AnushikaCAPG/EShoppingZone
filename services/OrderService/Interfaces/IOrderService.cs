using OrderService.DTOs;
using OrderService.Models;

namespace OrderService.Interfaces;

public interface IOrderService
{
    Task<Order> CheckoutAsync(CheckoutDto dto);

    Task<List<Order>> GetOrderHistoryAsync(int customerId);

    Task<Order?> GetOrderByIdAsync(int orderId);
}
