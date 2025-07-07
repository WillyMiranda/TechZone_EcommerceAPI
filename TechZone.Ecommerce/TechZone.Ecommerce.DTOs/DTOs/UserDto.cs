namespace TechZone.Ecommerce.DTOs.DTOs
{
    public sealed record UserDto(
        Guid Id,
        string? UserName,
        string? Email,
        string? NormalizedEmail,
        bool EmailConfirmed,
        string? PhoneNumber,
        bool PhoneNumberConfirmed,
        bool TwoFactorEnabled,
        DateTimeOffset? LockoutEnd,
        bool LockoutEnabled,
        int AccessFailedCount,
        Guid RoleId,
        string RoleName,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime LastAccessAt
    );
}
