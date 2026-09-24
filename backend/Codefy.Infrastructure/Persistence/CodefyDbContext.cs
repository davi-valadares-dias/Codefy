using Codefy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codefy.Infrastructure.Persistence;

public class CodefyDbContext : DbContext
{
    public CodefyDbContext(DbContextOptions<CodefyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectCategory> ProjectCategories => Set<ProjectCategory>();

    public DbSet<Technology> Technologies => Set<Technology>();
}
