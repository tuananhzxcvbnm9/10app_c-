using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;
namespace Ecommerce.Infrastructure.Persistence;
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.HasIndex(x => x.Name);
        });
    }
}
