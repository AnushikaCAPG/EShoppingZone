using Microsoft.AspNetCore.Mvc;
using WalletService.DTOs;
using WalletService.Interfaces;

namespace WalletService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletController(
        IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateWallet(
        CreateWalletDto dto)
    {
        var result =
            await _walletService.CreateWalletAsync(dto);

        return Ok(result);
    }

    [HttpPost("add-money")]
    public async Task<IActionResult> AddMoney(
        AddMoneyDto dto)
    {
        var result =
            await _walletService.AddMoneyAsync(dto);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetWallet(
        int customerId)
    {
        var result =
            await _walletService.GetWalletAsync(customerId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("transactions/{customerId}")]
    public async Task<IActionResult> Transactions(
        int customerId)
    {
        var result =
            await _walletService
                .GetTransactionsAsync(customerId);

        return Ok(result);
    }
}