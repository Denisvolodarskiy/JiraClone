using JiraClone.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Infrastructure.Persistence.Configuration.Write;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        
        builder.HasKey(p => p.ProjectId);
        builder.Property(p => p.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(p => p.Tasks)
               .WithOne(t => t.Project)
               .HasForeignKey(t => t.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}