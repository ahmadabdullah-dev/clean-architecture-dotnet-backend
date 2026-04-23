using Domain.Exceptions.Common;

public sealed class InvalidDomainOperationException : DomainException
{
    public string Operation { get; }
    public string Reason { get; }

    public InvalidDomainOperationException(string operation, string reason) : base("INVALID_OPERATION", $"Operation '{operation}' is invalid: {reason}")
    {
        Operation = string.IsNullOrWhiteSpace(operation) ? throw new ArgumentException("Operation name cannot be empty.", nameof(operation)) : operation;

        Reason = string.IsNullOrWhiteSpace(reason) ? throw new ArgumentException("Reason cannot be empty.", nameof(reason)) : reason;
    }

    public static InvalidDomainOperationException Because(string operation, string reason) => new(operation, reason);
}