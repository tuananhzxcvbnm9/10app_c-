using Microsoft.EntityFrameworkCore;
using Lms.Application.Abstractions;
using Lms.Domain.Entities;
using Lms.Infrastructure.Persistence;
namespace Lms.Infrastructure.Repositories;
public sealed class CourseRepository(AppDbContext dbContext) : ICourseRepository
{
    public async Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Courses.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Course> AddAsync(Course entity, CancellationToken cancellationToken)
    {
        dbContext.Courses.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
