using Codefy.Domain.Enums;

namespace Codefy.Application.Projects.Dtos;

public class CreateProjectRequest
{
    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string FullDescription { get; set; } = string.Empty;

    public DevelopmentStatus DevelopmentStatus { get; set; } =
        DevelopmentStatus.InDevelopment;

    public bool Featured { get; set; }

    public string? GitHubUrl { get; set; }

    public string? DemoUrl { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
