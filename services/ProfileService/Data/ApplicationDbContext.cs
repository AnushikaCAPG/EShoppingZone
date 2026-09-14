using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

namespace ProfileService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CustomerProfile> Profiles => Set<CustomerProfile>();
}
