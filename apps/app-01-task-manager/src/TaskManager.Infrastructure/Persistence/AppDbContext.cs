using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
namespace TaskManager.Infrastructure.Persistence;
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks => Set<Task>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.HasIndex(x => x.Name);
        });
    }
}
