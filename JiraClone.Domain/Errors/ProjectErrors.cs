

using JiraClone.Domain.Common;

namespace JiraClone.Domain.Errors;

public class ProjectErrors
{
    public static readonly ResultError ProjectWithTitleAlreadyExist = new(ErrorCodes.TitleExists, "Project with title already exist");

    public static readonly ResultError ProjectIsNotCreated =
        new (ErrorCodes.ProjectNotCreated, "Project instance is not created properly");

    public static readonly ResultError ProjectIsNotFound =
        new(ErrorCodes.ProjectNotFound, "Project with current id is not found.");


    public static readonly ResultError NoCreatedProjects = new(ErrorCodes.ProjectNotFound, "No projects have been created yet.");
}