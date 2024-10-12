using JiraClone.Infrastructure.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraClone.Infrastructure.Persistence.Configuration.Read
{
    internal class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).IsRequired();
        }
    }
}
