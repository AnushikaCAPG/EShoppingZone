using System.ComponentModel.DataAnnotations;

namespace WalletService.DTOs;

public class AddMoneyDto
{
    [Range(1, int.MaxValue)]
    public int CustomerId { get; set; }

    [Range(1, 1000000)]
    public decimal Amount { get; set; }
}
