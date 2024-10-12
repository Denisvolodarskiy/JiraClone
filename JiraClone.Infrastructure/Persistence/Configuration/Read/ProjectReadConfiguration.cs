using JiraClone.Infrastructure.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JiraClone.Infrastructure.Persistence.Configuration.Read;

public class ProjectReadConfiguration : IEntityTypeConfiguration<ProjectReadModel>
{
    public void Configure(EntityTypeBuilder<ProjectReadModel> builder)
    {
        builder.HasKey(p => p.ProjectId);
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}