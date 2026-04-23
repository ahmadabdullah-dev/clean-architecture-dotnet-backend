using Domain.Exceptions.Common;

public sealed class NotFoundException : DomainException
{
    public string ResourceName { get; }
    public object Identifier { get; }

    public NotFoundException(string resourceName, object identifier) : base("NOT_FOUND", $"{resourceName} with identifier '{identifier}' was not found.")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(resourceName);
        ResourceName = resourceName;
        Identifier = identifier;
    }

    public static NotFoundException For<T>(object identifier) => new(typeof(T).Name, identifier);
}