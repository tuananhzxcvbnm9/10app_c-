using Microsoft.EntityFrameworkCore;
using Crm.Domain.Entities;
namespace Crm.Infrastructure.Persistence;
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Lead> Leads => Set<Lead>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lead>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.HasIndex(x => x.Name);
        });
    }
}
