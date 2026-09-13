namespace AuthService.Models;

public class Transaction
{
    public int TransactionId { get; set; }

    public int WalletId { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } = string.Empty;

    public string ReferenceId { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public Wallet? Wallet { get; set; }
}