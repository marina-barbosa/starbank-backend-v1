
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain.Models;

namespace starbank_api.Domain;

public class StarDbContext : DbContext
{
    public StarDbContext(DbContextOptions<StarDbContext> options)
    : base(options)
    { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transation> Transations { get; set; }
    public DbSet<NaturalPerson> NaturalPersons { get; set; }
    public DbSet<LegalEntity> LegalEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(x => x.Email)
            .IsUnique();
        modelBuilder.Entity<LegalEntity>()
            .HasIndex(x => x.Cnpj)
            .IsUnique();
        modelBuilder.Entity<NaturalPerson>()
            .HasIndex(x => x.Cpf)
            .IsUnique();

    }
}

//      dotnet ef migrations add 

//      dotnet ef database update