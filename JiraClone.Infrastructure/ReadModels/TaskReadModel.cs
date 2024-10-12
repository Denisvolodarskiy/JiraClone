
namespace JiraClone.Infrastructure.ReadModels;

public class TaskReadModel
{
    public required int TaskId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public Guid? AssignedUserId { get; set; }
}
