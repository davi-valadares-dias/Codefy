using Codefy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codefy.Infrastructure.Persistence.Configurations;

public class TechnologyConfiguration
    : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder.ToTable("technologies");

        builder.HasKey(technology => technology.Id);

        builder.Property(technology => technology.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(technology => technology.Slug)
            .IsRequired()
            .HasMaxLength(120);

        builder.HasIndex(technology => technology.Slug)
            .IsUnique();

        builder.Property(technology => technology.Icon)
            .HasMaxLength(250);

        builder.Property(technology => technology.IsPublished)
            .IsRequired();

        builder.Property(technology => technology.DisplayOrder)
            .IsRequired();
    }
}
