using Codefy.Domain.Entities;

namespace Codefy.Application.Projects.Repositories;

public interface IProjectWriteRepository
{
    Task AddAsync(
        Project project,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
