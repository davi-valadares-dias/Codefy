using Codefy.Application.Projects.Repositories;
using Codefy.Domain.Entities;

namespace Codefy.Infrastructure.Persistence.Repositories;

public class ProjectWriteRepository : IProjectWriteRepository
{
    private readonly CodefyDbContext _dbContext;

    public ProjectWriteRepository(CodefyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        Project project,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Projects.AddAsync(
            project,
            cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
