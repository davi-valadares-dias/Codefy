using Codefy.Application.Projects.Repositories;
using Codefy.Application.Projects.UseCases.GetPublishedProjects;
using Codefy.Infrastructure.Persistence;
using Codefy.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("CodefyDatabase")
    ?? throw new InvalidOperationException(
        "A connection string 'CodefyDatabase' não foi encontrada.");

builder.Services.AddDbContext<CodefyDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IProjectReadRepository, ProjectReadRepository>();

builder.Services.AddScoped<GetPublishedProjectsUseCase>();

var app = builder.Build();

app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        service = "Codefy.Api"
    });
});

app.MapGet(
    "/api/v1/projects",
    async (
        GetPublishedProjectsUseCase useCase,
        CancellationToken cancellationToken) =>
    {
        var projects = await useCase.ExecuteAsync(cancellationToken);

        return Results.Ok(projects);
    });

app.Run();
