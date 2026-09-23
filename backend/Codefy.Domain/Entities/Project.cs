using Codefy.Domain.Enums;

namespace Codefy.Domain.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string FullDescription { get; set; } = string.Empty;

    public PublicationStatus Status { get; private set; } = PublicationStatus.Draft;

    public DevelopmentStatus DevelopmentStatus { get; set; } = DevelopmentStatus.InDevelopment;

    public bool Featured { get; set; }

    public string? GitHubUrl { get; set; }

    public string? DemoUrl { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? PublishedAt { get; private set; }

    public void Publish()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new InvalidOperationException(
                "O título é obrigatório para publicar o projeto.");

        if (string.IsNullOrWhiteSpace(Slug))
            throw new InvalidOperationException(
                "O slug é obrigatório para publicar o projeto.");

        if (string.IsNullOrWhiteSpace(ShortDescription))
            throw new InvalidOperationException(
                "A descrição curta é obrigatória para publicar o projeto.");

        if (string.IsNullOrWhiteSpace(FullDescription))
            throw new InvalidOperationException(
                "A descrição completa é obrigatória para publicar o projeto.");

        Status = PublicationStatus.Published;
        PublishedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Unpublish()
    {
        Status = PublicationStatus.Draft;
        PublishedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Archive()
    {
        Status = PublicationStatus.Archived;
        PublishedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
}
