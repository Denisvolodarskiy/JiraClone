using JiraClone.Domain.Common;

namespace JiraClone.Domain.Errors
{
    public class TaskErrors
    {
        public static readonly ResultError TaskNotFound = new(ErrorCodes.TaskNotFound, "Task is not found.");
        public static readonly ResultError TaskWithTitleAlreadyExist = new(ErrorCodes.TaskWithTitleExists, "Project with title already exist");
    }
}