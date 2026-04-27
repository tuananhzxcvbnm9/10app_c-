using Microsoft.EntityFrameworkCore;
using Blog.Domain.Entities;
namespace Blog.Infrastructure.Persistence;
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.HasIndex(x => x.Name);
        });
    }
}
