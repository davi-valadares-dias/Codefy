namespace Codefy.Domain.Entities;

public class ProjectCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
