using Codefy.Domain.Enums;

namespace Codefy.Domain.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string FullDescription { get; set; } = string.Empty;

    public PublicationStatus Status { get; set; } = PublicationStatus.Draft;
}
