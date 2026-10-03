using Codefy.Infrastructure.Persistence;
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

var app = builder.Build();

app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        service = "Codefy.Api"
    });
});

app.Run();
