using Codefy.Domain.Entities;
using Codefy.Domain.Enums;

namespace Codefy.Domain.Tests;

public class ProjectTests
{
    [Fact]
    public void Publish_ShouldThrowException_WhenTitleIsEmpty()
    {
        var project = new Project
        {
            Slug = "codefy",
            ShortDescription = "Portfólio profissional.",
            FullDescription = "Sistema completo de portfólio profissional."
        };

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            project.Publish();
        });

        Assert.Equal(
            "O título é obrigatório para publicar o projeto.",
            exception.Message);

        Assert.Equal(PublicationStatus.Draft, project.Status);
        Assert.Null(project.PublishedAt);
    }

    [Fact]
    public void Publish_ShouldThrowException_WhenCategoryIsMissing()
    {
        var project = new Project
        {
            Title = "Codefy",
            Slug = "codefy",
            ShortDescription = "Portfólio profissional.",
            FullDescription = "Sistema completo de portfólio profissional."
        };

        project.Technologies.Add(new Technology
        {
            Name = "C#",
            Slug = "csharp"
        });

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            project.Publish();
        });

        Assert.Equal(
            "A categoria é obrigatória para publicar o projeto.",
            exception.Message);
    }

    [Fact]
    public void Publish_ShouldThrowException_WhenTechnologyIsMissing()
    {
        var project = new Project
        {
            Title = "Codefy",
            Slug = "codefy",
            ShortDescription = "Portfólio profissional.",
            FullDescription = "Sistema completo de portfólio profissional.",
            Category = new ProjectCategory
            {
                Name = "Full-stack",
                Slug = "full-stack"
            }
        };

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            project.Publish();
        });

        Assert.Equal(
            "Pelo menos uma tecnologia é obrigatória para publicar o projeto.",
            exception.Message);
    }

    [Fact]
    public void Publish_ShouldPublishProject_WhenRequiredFieldsAreFilled()
    {
        var project = new Project
        {
            Title = "Codefy",
            Slug = "codefy",
            ShortDescription = "Portfólio profissional.",
            FullDescription = "Sistema completo de portfólio profissional.",
            Category = new ProjectCategory
            {
                Name = "Full-stack",
                Slug = "full-stack"
            }
        };

        project.Technologies.Add(new Technology
        {
            Name = "C#",
            Slug = "csharp"
        });

        project.Publish();

        Assert.Equal(PublicationStatus.Published, project.Status);
        Assert.NotNull(project.PublishedAt);
    }
}
