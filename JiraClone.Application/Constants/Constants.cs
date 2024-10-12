
namespace JiraClone.Application.Constants;

public static class ApplicationConstants
{
    public static class Roles
    {
        public static readonly string[] RoleNames = ["Admin", "Project Manager", "Developer", "Tester"];

    }

    public static class Validators
    {
        public const int TitleNameMinLength = 3;
        public const int TitleNameMaxLength = 50;

        public const int AssignedUserIdLength = 36;

        public const int PasswordMinLength = 6;

        public const int TaskDescriptionMaxLength = 500;

        public const string Email = "Email";
        public const string Password = "Password";
        public const string Role = "Role";

        public const string ProjectId = "Project Id";

        public const string Title = "Title";
        public const string TaskId = "Task Id";

        public const string TaskDescriptionMaxLengthWarningMessage = "Description must be less than or equal to 500 characters.";
        public const string AssignedUserIdLengthWarningMessage = "AssignedUserId must be null, empty, or a valid GUID with 36 characters.";
    }
}