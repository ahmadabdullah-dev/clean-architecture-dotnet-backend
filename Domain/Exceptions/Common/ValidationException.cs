namespace Domain.Exceptions.Common;
public sealed class ValidationException : DomainException
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public ValidationException(IReadOnlyDictionary<string, string[]> errors) : base("VALIDATION_FAILED", "One or more validation errors occurred.")
    {
        ArgumentNullException.ThrowIfNull(errors);
        Errors = errors;
    }

    public ValidationException(string field, string error) : this(new Dictionary<string, string[]> {{ field, [error] }})
    {
    }

    public ValidationException(string field, IEnumerable<string> errors) : this(new Dictionary<string, string[]>{{ field, errors.ToArray() }})
    {
    }

    public static ValidationException For(string field, string error) => new(field, error);
}