

namespace JiraClone.Domain.Entities;

public class Project(string title)
{
    public int ProjectId { get; private set; }
    public string Title { get; private set; } = title;
    public ICollection<Task> Tasks { get; set; } = new List<Task>();

    public void UpdateTitle(string title)
    {
        Title = title;
    }
}
