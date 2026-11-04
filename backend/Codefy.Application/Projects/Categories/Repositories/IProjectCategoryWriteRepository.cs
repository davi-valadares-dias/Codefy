using Codefy.Domain.Entities;

namespace Codefy.Application.Projects.Categories.Repositories;

public interface IProjectCategoryWriteRepository
{
    Task<bool> ExistsBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        ProjectCategory category,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
