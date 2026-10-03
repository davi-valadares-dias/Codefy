using Codefy.Application.Projects.Dtos;
using Codefy.Application.Projects.Repositories;
using Codefy.Domain.Entities;

namespace Codefy.Application.Projects.UseCases.CreateProject;

public class CreateProjectUseCase
{
    private readonly IProjectWriteRepository _projectRepository;

    public CreateProjectUseCase(
        IProjectWriteRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Guid> ExecuteAsync(
        CreateProjectRequest request,
        CancellationToken cancellationToken = default)
    {
        var project = new Project
        {
            Title = request.Title.Trim(),
            Slug = request.Slug.Trim(),
            ShortDescription = request.ShortDescription.Trim(),
            FullDescription = request.FullDescription.Trim(),
            DevelopmentStatus = request.DevelopmentStatus,
            Featured = request.Featured,
            GitHubUrl = request.GitHubUrl,
            DemoUrl = request.DemoUrl,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        await _projectRepository.AddAsync(
            project,
            cancellationToken);

        await _projectRepository.SaveChangesAsync(
            cancellationToken);

        return project.Id;
    }
}
