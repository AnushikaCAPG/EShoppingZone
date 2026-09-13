using System.ComponentModel.DataAnnotations;

namespace WalletService.DTOs;

public class CreateWalletDto
{
    [Range(1, int.MaxValue)]
    public int CustomerId { get; set; }
}
