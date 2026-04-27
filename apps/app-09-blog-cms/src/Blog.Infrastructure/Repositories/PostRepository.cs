using Microsoft.EntityFrameworkCore;
using Blog.Application.Abstractions;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
namespace Blog.Infrastructure.Repositories;
public sealed class PostRepository(AppDbContext dbContext) : IPostRepository
{
    public async Task<IReadOnlyList<Post>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Posts.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Post> AddAsync(Post entity, CancellationToken cancellationToken)
    {
        dbContext.Posts.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
