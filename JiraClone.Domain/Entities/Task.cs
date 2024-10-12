
using JiraClone.Domain.Entities.ApplicationUser;

namespace JiraClone.Domain.Entities;

public class Task
{
    public int TaskId { get; private set; }
    public required string Title { get; set; }
    public string? Description { get; set; } = string.Empty;
  
    public int ProjectId { get; private set; }
    public Guid? AssignedUserId { get; set; }

    public Project Project { get; set; }
    public User? AssignedUser { get; set; }
}
