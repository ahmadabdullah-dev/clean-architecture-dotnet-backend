namespace Domain.Exceptions.Auth;

public sealed class UnauthorizedException : DomainException
{
    public UnauthorizedException() : base("Unauthorized access.") {}

    public UnauthorizedException(string message) : base(message) {}

    public UnauthorizedException(string message, Exception innerException) : base(message, innerException) {}
}