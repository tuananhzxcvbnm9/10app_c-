using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence;
namespace TaskManager.Infrastructure.Repositories;
public sealed class TaskRepository(AppDbContext dbContext) : ITaskRepository
{
    public async Task<IReadOnlyList<Task>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Tasks.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Task> AddAsync(Task entity, CancellationToken cancellationToken)
    {
        dbContext.Tasks.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
