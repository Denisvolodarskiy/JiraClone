

namespace JiraClone.Domain.Common;



//public class Result<T>
//{
//    public bool IsSuccess { get; }
//    public T Value { get; }
//    public string Error { get; }
//    public HttpStatusCode StatusCode { get; }

//    private Result(bool isSuccess, T value, string error, HttpStatusCode statusCode)
//    {
//        IsSuccess = isSuccess;
//        Value = value;
//        Error = error;
//        StatusCode = statusCode;
//    }

//    public static Result<T> Success(T value)
//    {
//        return new Result<T>(true, value, null, statusCode: HttpStatusCode.OK);
//    }

//    public static Result<T> Failure(string error, HttpStatusCode statusCode)
//    {
//        return new Result<T>(false, default(T), error, statusCode);
//    }
//}

