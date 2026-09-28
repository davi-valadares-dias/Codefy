using Codefy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Codefy.Api;

public class CodefyDbContextFactory
    : IDesignTimeDbContextFactory<CodefyDbContext>
{
    public CodefyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<CodefyDbContextFactory>()
            .AddEnvironmentVariables()
            .Build();

        var connectionString =
            configuration.GetConnectionString("CodefyDatabase")
            ?? throw new InvalidOperationException(
                "A connection string 'CodefyDatabase' não foi encontrada.");

        var options = new DbContextOptionsBuilder<CodefyDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new CodefyDbContext(options);
    }
}
