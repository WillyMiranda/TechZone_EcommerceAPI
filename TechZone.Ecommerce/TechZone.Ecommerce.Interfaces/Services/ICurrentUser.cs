namespace TechZone.Ecommerce.Interfaces.Services
{
    public interface ICurrentUser
    {
        Guid? UserId { get; }
        string? UserName { get; }
        string? Email { get; }
        string? Role { get; }
        bool IsAuthenticated { get; }
    }
}
