namespace JiraClone.Domain.Common;

public record ResultError(string Code, string? Message = null)
{
    public static readonly ResultError None = new(string.Empty);

    public static implicit operator Result(ResultError error) => Result.Failure(error);
}