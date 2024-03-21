using Microsoft.EntityFrameworkCore;

namespace StarBank.Domain;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
    {
    }
}

