using Lms.Domain.Entities;
namespace Lms.Application.Abstractions;
public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken);
    Task<Course> AddAsync(Course entity, CancellationToken cancellationToken);
}
