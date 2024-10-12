
using JiraClone.Domain.Common;

namespace JiraClone.Domain.Errors;

public class JwtErrors
{
    public static readonly ResultError TokenIsNotCreated = new(ErrorCodes.JwtIsNotCreated, "Jwt token is not created");
}