using Codefy.Application.Projects.Dtos;

namespace Codefy.Application.Projects.Repositories;

public interface IProjectReadRepository
{
    Task<IReadOnlyList<ProjectListItemDto>> GetPublishedAsync(
        CancellationToken cancellationToken = default);
}
