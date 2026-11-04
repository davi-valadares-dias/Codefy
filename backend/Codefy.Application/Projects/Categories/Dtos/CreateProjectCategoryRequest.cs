namespace Codefy.Application.Projects.Categories.Dtos;

public class CreateProjectCategoryRequest
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}
