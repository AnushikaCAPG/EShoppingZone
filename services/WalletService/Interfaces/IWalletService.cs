using WalletService.DTOs;
using WalletService.Models;

namespace WalletService.Interfaces;

public interface IWalletService
{
    Task<Wallet> CreateWalletAsync(CreateWalletDto dto);

    Task<Wallet?> AddMoneyAsync(AddMoneyDto dto);

    Task<Wallet?> GetWalletAsync(int customerId);

    Task<List<Transaction>> GetTransactionsAsync(int customerId);
}
