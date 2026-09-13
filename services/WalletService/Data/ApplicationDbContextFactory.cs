using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WalletService.Data;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=LIN-5CD6291Y3Z\\SQLEXPRESS;Database=EShoppingZone_WalletDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new ApplicationDbContext(
            optionsBuilder.Options);
    }
}
