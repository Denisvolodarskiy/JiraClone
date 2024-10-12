

using JiraClone.Domain.Common;

namespace JiraClone.Domain.Errors;

public class UserErrors
{
    public static readonly ResultError UserIsNotFound = new(ErrorCodes.UserNotFound, "User is not found.");
    public static readonly ResultError UserIsNotCreated = new(ErrorCodes.UserNotCreated, "An error occurred creating the user");
    public static readonly ResultError UserIsNotValid = new(ErrorCodes.UserNotValid, "User is not valid");
}