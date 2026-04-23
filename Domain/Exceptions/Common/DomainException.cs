namespace Domain.Exceptions.Common;

public abstract class DomainException : Exception
{
    public string? Code { get; }

    protected DomainException(string message) : base(message) {}

    protected DomainException(string code, string message) : base(message)
    {
        Code = code;
    }

    protected DomainException(string message, Exception innerException) : base(message, innerException) {}
}