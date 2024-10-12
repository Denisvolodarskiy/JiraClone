using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task = JiraClone.Domain.Entities.Task;

namespace JiraClone.Infrastructure.Persistence.Configuration.Write;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(t => t.TaskId);
        builder.Property(t => t.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasMaxLength(500);
     
        builder.HasOne(t => t.AssignedUser)
               .WithMany(u => u.AssignedTasks)
               .HasForeignKey(t => t.AssignedUserId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
