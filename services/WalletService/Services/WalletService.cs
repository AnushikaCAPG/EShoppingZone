using Microsoft.EntityFrameworkCore;
using WalletService.Data;
using WalletService.DTOs;
using WalletService.Interfaces;
using WalletService.Models;

namespace WalletService.Services;

public class WalletService : IWalletService
{
    private readonly ApplicationDbContext _context;

    public WalletService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Wallet> CreateWalletAsync(
        CreateWalletDto dto)
    {
        var wallet = new Wallet
        {
            CustomerId = dto.CustomerId,
            Balance = 0
        };

        _context.Wallets.Add(wallet);

        await _context.SaveChangesAsync();

        return wallet;
    }

    public async Task<Wallet?> AddMoneyAsync(
        AddMoneyDto dto)
    {
        var wallet = await _context.Wallets
            .FirstOrDefaultAsync(
                x => x.CustomerId == dto.CustomerId);

        if (wallet == null)
        {
            return null;
        }

        wallet.Balance += dto.Amount;

        var transaction = new Transaction
        {
            WalletId = wallet.WalletId,
            Amount = dto.Amount,
            TransactionType = "Credit"
        };

        _context.Transactions.Add(transaction);

        await _context.SaveChangesAsync();

        return wallet;
    }

    public async Task<Wallet?> GetWalletAsync(
        int customerId)
    {
        return await _context.Wallets
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);
    }

    public async Task<List<Transaction>> GetTransactionsAsync(
        int customerId)
    {
        var wallet = await _context.Wallets
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);

        if (wallet == null)
        {
            return new List<Transaction>();
        }

        return await _context.Transactions
            .Where(x => x.WalletId == wallet.WalletId)
            .ToListAsync();
    }
}