using Microsoft.EntityFrameworkCore;

namespace StarBank.Domain;

public class BancoDbContext : DbContext
{
    public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
    {
    }
}

