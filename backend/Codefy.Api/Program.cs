using Codefy.Application.Projects.Categories.Dtos;
using Codefy.Application.Projects.Categories.Repositories;
using Codefy.Application.Projects.Categories.UseCases.CreateProjectCategory;
using Codefy.Application.Projects.Dtos;
using Codefy.Application.Projects.Repositories;
using Codefy.Application.Projects.UseCases.CreateProject;
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
builder.Services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();

builder.Services.AddScoped<
    IProjectCategoryWriteRepository,
    ProjectCategoryWriteRepository>();

builder.Services.AddScoped<GetPublishedProjectsUseCase>();
builder.Services.AddScoped<CreateProjectUseCase>();
builder.Services.AddScoped<CreateProjectCategoryUseCase>();

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

if (app.Environment.IsDevelopment())
{
    app.MapPost(
        "/api/dev/projects",
        async (
            CreateProjectRequest request,
            CreateProjectUseCase useCase,
            CancellationToken cancellationToken) =>
        {
            var projectId = await useCase.ExecuteAsync(
                request,
                cancellationToken);

            return Results.Created(
                $"/api/dev/projects/{projectId}",
                new
                {
                    id = projectId
                });
        });

    app.MapPost(
        "/api/dev/project-categories",
        async (
            CreateProjectCategoryRequest request,
            CreateProjectCategoryUseCase useCase,
            CancellationToken cancellationToken) =>
        {
            var categoryId = await useCase.ExecuteAsync(
                request,
                cancellationToken);

            return Results.Created(
                $"/api/dev/project-categories/{categoryId}",
                new
                {
                    id = categoryId
                });
        });
}

app.Run();
