using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, Domain.Enums.User.UserRole role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string email, string password, string firstName, string lastName, DateOnly dateOfBirth, Domain.Enums.User.UserRole role = Domain.Enums.User.UserRole.Member);

    Task<Result> DeleteUserAsync(string userId);
}
