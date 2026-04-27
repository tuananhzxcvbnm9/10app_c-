using Microsoft.EntityFrameworkCore;
using Lms.Domain.Entities;
namespace Lms.Infrastructure.Persistence;
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.HasIndex(x => x.Name);
        });
    }
}
