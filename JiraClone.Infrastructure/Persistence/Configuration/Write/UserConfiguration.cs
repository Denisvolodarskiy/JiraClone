using JiraClone.Domain.Entities.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraClone.Infrastructure.Persistence.Configuration.Write
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.AssignedTasks)
                .WithOne(pt => pt.AssignedUser)
                .HasForeignKey(pt => pt.AssignedUserId);
        }
    }
}
