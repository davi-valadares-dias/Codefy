namespace Codefy.Domain.Entities;

public class Technology
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Icon { get; set; }

    public bool IsPublished { get; set; } = true;

    public int DisplayOrder { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
