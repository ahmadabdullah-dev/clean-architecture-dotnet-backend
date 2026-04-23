using Domain.Enums.User;
using Domain.Events.Common;

namespace Domain.Events.User.Base;

public sealed record UserCreatedEvent(
    string UserId,
    string Email,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    UserRole Role,
    DateTimeOffset CreatedAt
) : IDomainEvent;

public sealed record UserEmailChangedEvent(
    string UserId,
    string OldEmail,
    string NewEmail,
    DateTimeOffset ChangedAt
) : IDomainEvent;

public sealed record UserProfileUpdatedEvent(
    string UserId,
    string FirstName,
    string LastName,
    DateTimeOffset UpdatedAt
) : IDomainEvent;

public sealed record UserRoleChangedEvent(
    string UserId,
    UserRole OldRole,
    UserRole NewRole,
    DateTimeOffset ChangedAt
) : IDomainEvent;