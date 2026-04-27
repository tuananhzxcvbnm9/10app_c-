using TaskManager.Domain.Entities;
namespace TaskManager.Application.Abstractions;
public interface ITaskRepository
{
    Task<IReadOnlyList<Task>> GetAllAsync(CancellationToken cancellationToken);
    Task<Task> AddAsync(Task entity, CancellationToken cancellationToken);
}
