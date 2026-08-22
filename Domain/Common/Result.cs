namespace Gastos.Domain.Common;

public sealed class Result
{
    private Result(bool isSuccess, IReadOnlyCollection<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public IReadOnlyCollection<Error> Errors { get; }

    public static Result Success() => new(true, []);

    public static Result Failure(params Error[] errors) => new(false, errors);
}

public sealed class Result<T>
{
    private Result(bool isSuccess, T? value, IReadOnlyCollection<Error> errors)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public T? Value { get; }

    public IReadOnlyCollection<Error> Errors { get; }

    public static Result<T> Success(T value) => new(true, value, []);

    public static Result<T> Failure(params Error[] errors) => new(false, default, errors);
}
