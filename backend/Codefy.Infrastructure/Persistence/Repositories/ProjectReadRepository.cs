using Codefy.Application.Projects.Dtos;
using Codefy.Application.Projects.Repositories;
using Codefy.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Codefy.Infrastructure.Persistence.Repositories;

public class ProjectReadRepository : IProjectReadRepository
{
    private readonly CodefyDbContext _dbContext;

    public ProjectReadRepository(CodefyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ProjectListItemDto>> GetPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .Where(project =>
                project.Status == PublicationStatus.Published)
            .OrderByDescending(project => project.Featured)
            .ThenByDescending(project => project.PublishedAt)
            .Select(project => new ProjectListItemDto
            {
                Id = project.Id,
                Title = project.Title,
                Slug = project.Slug,
                ShortDescription = project.ShortDescription,
                DevelopmentStatus = project.DevelopmentStatus,
                Featured = project.Featured,
                Category = project.Category != null
                    ? project.Category.Name
                    : null,
                Technologies = project.Technologies
                    .Where(technology => technology.IsPublished)
                    .OrderBy(technology => technology.DisplayOrder)
                    .Select(technology => technology.Name)
                    .ToList()
            })
            .ToListAsync(cancellationToken);
    }
}
