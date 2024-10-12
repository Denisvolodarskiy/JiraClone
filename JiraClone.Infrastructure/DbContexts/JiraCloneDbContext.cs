using JiraClone.Domain.Entities;
using JiraClone.Domain.Entities.ApplicationUser;
using JiraClone.Infrastructure.Persistence.Configuration.Read;
using JiraClone.Infrastructure.Persistence.Configuration.Write;
using JiraClone.Infrastructure.ReadModel;
using JiraClone.Infrastructure.ReadModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = JiraClone.Domain.Entities.Task;


namespace JiraClone.Infrastructure.DbContexts;

public class JiraCloneDbContext: IdentityDbContext<User, UserRole, Guid> 
{
    public JiraCloneDbContext(DbContextOptions<JiraCloneDbContext> options)
       : base(options)
    {

    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserReadModel> UserReadModels { get; set; }
    public DbSet<ProjectReadModel> ProjectReadModels { get; set; }
    public DbSet<TaskReadModel> TaskReadModels { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectReadConfiguration());
        modelBuilder.ApplyConfiguration(new TaskReadConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserReadConfiguration());

        modelBuilder.Entity<UserRole>().ToTable(Constants.Constants.DataBase.UserRoleTableName);
        modelBuilder.Entity<User>().ToTable(Constants.Constants.DataBase.UsersTableName);

        base.OnModelCreating(modelBuilder);
    }
}