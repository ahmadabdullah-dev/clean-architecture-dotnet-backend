namespace Domain.ValueObjects.Contact;

public sealed record Address
{
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    public string ZipCode { get; init; }

    public Address(string street, string city, string state, string country, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new InvalidDomainOperationException(nameof(Address), "Street cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(city))
            throw new InvalidDomainOperationException(nameof(Address), "City cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(state))
            throw new InvalidDomainOperationException(nameof(Address), "State cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(country))
            throw new InvalidDomainOperationException(nameof(Address), "Country cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new InvalidDomainOperationException(nameof(Address), "ZipCode cannot be null or empty.");

        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        Country = country.Trim();
        ZipCode = zipCode.Trim();
    }

    public override string ToString() => $"{Street}, {City}, {State} {ZipCode}, {Country}";
}