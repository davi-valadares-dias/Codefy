using Codefy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codefy.Infrastructure.Persistence.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(project => project.Id);

        builder.Property(project => project.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(project => project.Slug)
            .IsRequired()
            .HasMaxLength(160);

        builder.HasIndex(project => project.Slug)
            .IsUnique();

        builder.Property(project => project.ShortDescription)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(project => project.FullDescription)
            .IsRequired();

        builder.Property(project => project.GitHubUrl)
            .HasMaxLength(500);

        builder.Property(project => project.DemoUrl)
            .HasMaxLength(500);

        builder.Property(project => project.Status)
            .IsRequired();

        builder.Property(project => project.DevelopmentStatus)
            .IsRequired();

        builder.Property(project => project.Featured)
            .IsRequired();

        builder.Property(project => project.CreatedAt)
            .IsRequired();

        builder.Property(project => project.UpdatedAt)
            .IsRequired();

        builder.HasOne(project => project.Category)
            .WithMany(category => category.Projects)
            .HasForeignKey(project => project.ProjectCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(project => project.Technologies)
            .WithMany(technology => technology.Projects)
            .UsingEntity(join => join.ToTable("project_technologies"));
    }
}
