namespace CalculatorApp.Model;

public abstract class Result<T>
{
    public bool isSuccess { get; }

    protected Result(bool isSuccess)
    {
        this.isSuccess = isSuccess;
    }

}


public sealed class Success<T> : Result<T>
{
    public T value { get; }
    public Success(T value) : base(true)
    {
        this.value = value;
    }
}

public sealed class Failure<T> : Result<T>
{
    public Exception exception { get; }
    public Failure(Exception exception) : base(false)
    {
        this.exception = exception;
    }
}