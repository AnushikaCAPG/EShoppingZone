namespace AuthService.Models;

public class Wallet
{
    public int WalletId { get; set; }

    public int CustomerId { get; set; }

    public decimal Balance { get; set; }

    public Customer? Customer { get; set; }
}