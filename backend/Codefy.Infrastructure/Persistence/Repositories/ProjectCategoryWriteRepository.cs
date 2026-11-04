using Codefy.Application.Projects.Categories.Repositories;
using Codefy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codefy.Infrastructure.Persistence.Repositories;

public class ProjectCategoryWriteRepository
    : IProjectCategoryWriteRepository
{
    private readonly CodefyDbContext _dbContext;

    public ProjectCategoryWriteRepository(CodefyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistsBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProjectCategories
            .AsNoTracking()
            .AnyAsync(
                category => category.Slug == slug,
                cancellationToken);
    }

    public async Task AddAsync(
        ProjectCategory category,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.ProjectCategories.AddAsync(
            category,
            cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
