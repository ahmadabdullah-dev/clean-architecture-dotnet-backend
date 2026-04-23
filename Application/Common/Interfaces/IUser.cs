using Domain.Enums.User;
namespace Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; }
    UserRole Role { get; }
}
