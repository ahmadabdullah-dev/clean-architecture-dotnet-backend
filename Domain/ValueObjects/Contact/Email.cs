using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Contact;

public sealed record Email
{
    private static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; init; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidDomainOperationException(nameof(Email), "Email value cannot be null or empty.");

        var normalizedValue = value.Trim().ToLowerInvariant();

        if (!IsValidEmail(normalizedValue))
            throw new InvalidDomainOperationException(nameof(Email), $"The value '{value}' is not a valid email format.");

        Value = normalizedValue;
    }

    public string GetDomain() => Value.Split('@')[1];

    public string GetLocalPart() => Value.Split('@')[0];

    public bool IsFromDomain(string domain) =>
        GetDomain().Equals(domain.Trim().ToLowerInvariant(), StringComparison.OrdinalIgnoreCase);

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;

    public static explicit operator Email(string value) => new(value);

    public static bool TryCreate(string value, out Email? email)
    {
        try
        {
            email = new Email(value);
            return true;
        }
        catch (InvalidDomainOperationException)
        {
            email = null;
            return false;
        }
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}