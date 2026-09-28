using Codefy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codefy.Infrastructure.Persistence.Configurations;

public class ProjectCategoryConfiguration
    : IEntityTypeConfiguration<ProjectCategory>
{
    public void Configure(EntityTypeBuilder<ProjectCategory> builder)
    {
        builder.ToTable("project_categories");

        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(category => category.Slug)
            .IsRequired()
            .HasMaxLength(120);

        builder.HasIndex(category => category.Slug)
            .IsUnique();

        builder.Property(category => category.DisplayOrder)
            .IsRequired();
    }
}
