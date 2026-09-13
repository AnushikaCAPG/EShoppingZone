using Microsoft.AspNetCore.Mvc;
using OrderService.DTOs;
using OrderService.Interfaces;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(
        IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(
        CheckoutDto dto)
    {
        var result =
            await _orderService.CheckoutAsync(dto);

        return Ok(result);
    }

    [HttpGet("history/{customerId}")]
    public async Task<IActionResult> History(
        int customerId)
    {
        var result =
            await _orderService
                .GetOrderHistoryAsync(customerId);

        return Ok(result);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrder(
        int orderId)
    {
        var result =
            await _orderService
                .GetOrderByIdAsync(orderId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
