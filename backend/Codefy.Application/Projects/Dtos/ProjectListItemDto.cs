using Codefy.Domain.Enums;

namespace Codefy.Application.Projects.Dtos;

public class ProjectListItemDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public DevelopmentStatus DevelopmentStatus { get; set; }

    public bool Featured { get; set; }

    public string? Category { get; set; }

    public List<string> Technologies { get; set; } = [];
}
