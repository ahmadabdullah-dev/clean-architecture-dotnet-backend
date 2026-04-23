using Domain.Enums.User;
namespace Application.Common.Security;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeAttribute : Attribute
{ 
    public AuthorizeAttribute() { } 
    public UserRole[] Roles { get; set; } = [];
    public string Policy { get; set; } = string.Empty;
}
