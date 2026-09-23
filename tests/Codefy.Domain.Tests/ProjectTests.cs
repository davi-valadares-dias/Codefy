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
    public void Publish_ShouldPublishProject_WhenRequiredFieldsAreFilled()
    {
        var project = new Project
        {
            Title = "Codefy",
            Slug = "codefy",
            ShortDescription = "Portfólio profissional.",
            FullDescription = "Sistema completo de portfólio profissional."
        };

        project.Publish();

        Assert.Equal(PublicationStatus.Published, project.Status);
        Assert.NotNull(project.PublishedAt);
    }
}
