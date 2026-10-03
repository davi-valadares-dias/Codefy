using Codefy.Application.Projects.Dtos;
using Codefy.Application.Projects.Repositories;

namespace Codefy.Application.Projects.UseCases.GetPublishedProjects;

public class GetPublishedProjectsUseCase
{
    private readonly IProjectReadRepository _projectRepository;

    public GetPublishedProjectsUseCase(
        IProjectReadRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IReadOnlyList<ProjectListItemDto>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return await _projectRepository.GetPublishedAsync(cancellationToken);
    }
}
