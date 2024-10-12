using JiraClone.Infrastructure.ReadModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JiraClone.Infrastructure.Persistence.Configuration.Read;

public class TaskReadConfiguration : IEntityTypeConfiguration<TaskReadModel>
{
    public void Configure(EntityTypeBuilder<TaskReadModel> builder)
    {
        builder.HasKey(t => t.TaskId);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasMaxLength(500);
        builder.Property(t => t.AssignedUserId)
            .IsRequired(false);
    }
}
