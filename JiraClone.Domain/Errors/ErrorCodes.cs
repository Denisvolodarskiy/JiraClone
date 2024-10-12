namespace JiraClone.Domain.Errors;

public sealed record ErrorCodes
{
    public const string TitleExists = "Project.TitleExists";
    public const string ProjectNotFound = "Project.NotFound";
    public const string ProjectNotCreated = "Project.NotCreated";
    

    public const string TaskNotFound = "Task.NotFound";
    public const string TaskWithTitleExists = "Task.TitleExists"; 
    
    public const string UserNotFound = "User.NotFound";
    public const string UserNotCreated = "User.NotCreated";
    public const string UserNotValid= "User.NotValid";

    public const string JwtIsNotCreated = "Jwt.NotCreated";
}