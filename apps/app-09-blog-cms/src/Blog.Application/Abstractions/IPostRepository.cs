using Blog.Domain.Entities;
namespace Blog.Application.Abstractions;
public interface IPostRepository
{
    Task<IReadOnlyList<Post>> GetAllAsync(CancellationToken cancellationToken);
    Task<Post> AddAsync(Post entity, CancellationToken cancellationToken);
}
