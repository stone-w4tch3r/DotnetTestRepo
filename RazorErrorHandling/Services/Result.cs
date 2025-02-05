namespace RazorErrorHandling.Services;

public class Result<T>
{
    public bool Success { get; private set; }
    public T Data { get; private set; }
    public string ErrorMessage { get; private set; }
    public ErrorType ErrorType { get; private set; }

    public static Result<T> Ok(T data) => new Result<T> { Success = true, Data = data };

    public static Result<T> Fail(string message, ErrorType errorType) =>
        new Result<T>
        {
            Success = false,
            ErrorMessage = message,
            ErrorType = errorType,
        };
}

public enum ErrorType
{
    Validation,
    NotFound,
    Conflict,
    System,
}
