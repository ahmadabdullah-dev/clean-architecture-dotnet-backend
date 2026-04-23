using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Contact;

public sealed record PhoneNumber
{
    private static readonly Regex PhoneRegex = new(@"^\+[1-9]\d{1,14}$", RegexOptions.Compiled);

    public string Value { get; init; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidDomainOperationException(nameof(PhoneNumber), "Phone number cannot be null or empty.");

        var normalizedValue = value.Trim();

        if (!normalizedValue.StartsWith('+')) normalizedValue = "+" + normalizedValue;

        normalizedValue = Regex.Replace(normalizedValue, @"[^\d+]", "");

        if (!PhoneRegex.IsMatch(normalizedValue))
            throw new InvalidDomainOperationException(nameof(PhoneNumber), "Invalid phone number format. Must include country code and be up to 15 digits.");

        Value = normalizedValue;
    }

    public string GetCountryCode()
    {
        var match = Regex.Match(Value, @"^\+(\d{1,3})");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    public string GetNationalNumber() => Value[(GetCountryCode().Length + 1)..];

    public override string ToString() => Value;

    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    public static explicit operator PhoneNumber(string value) => new(value);

    public static PhoneNumber FromCountryAndNumber(string countryCode, string nationalNumber)
    {
        var cleanNumber = Regex.Replace(nationalNumber, @"\D", "");
        return new PhoneNumber($"+{countryCode}{cleanNumber}");
    }

    public static bool TryCreate(string value, out PhoneNumber? phoneNumber)
    {
        try
        {
            phoneNumber = new PhoneNumber(value);
            return true;
        }
        catch (InvalidDomainOperationException)
        {
            phoneNumber = null;
            return false;
        }
    }
}