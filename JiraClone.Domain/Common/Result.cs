namespace JiraClone.Domain.Common;

public class Result
{
    public bool IsSuccess => Error == ResultError.None;
    public ResultError Error { get; }

    protected Result(ResultError error)
    {
        Error = error;
    }

    public static Result Success()
    {
        return new(ResultError.None);
    }

    public static Result Failure(ResultError error)
    {
        return new(error);
    }

}

public class Result<T> : Result
{
    public T? Value { get; }
    protected Result(T value, ResultError error) : base(error)
    {

        Value = value;
    }

    public static Result<T> Success(T value) => new(value, ResultError.None);

    public new static Result<T> Failure(ResultError error) => error != ResultError.None ? new(default!, error) : throw new ArgumentException("Failed to create error result");

    public static implicit operator Result<T>(ResultError error) => Failure(error);
    public static implicit operator Result<T>(T value) => Success(value);
}