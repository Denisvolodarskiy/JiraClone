

namespace JiraClone.Infrastructure.ReadModels;

public class UserReadModel
{
    public Guid UserId { get; set; }

    public string? BearerToken { get; set; } 
}
