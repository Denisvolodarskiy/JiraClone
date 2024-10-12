using Microsoft.AspNetCore.Identity;

namespace JiraClone.Domain.Entities.ApplicationUser;

public class User : IdentityUser<Guid>
{
    public required string Role { get; set; }
    public ICollection<Task> AssignedTasks { get; set; } = [];
}
