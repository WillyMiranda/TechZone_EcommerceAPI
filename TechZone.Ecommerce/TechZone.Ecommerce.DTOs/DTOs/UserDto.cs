namespace TechZone.Ecommerce.DTOs.DTOs
{
    public sealed record UserDto
    {
        public Guid Id { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? NormalizedEmail { get; init; }
        public bool EmailConfirmed { get; init; }
        public string? PhoneNumber { get; init; }
        public bool PhoneNumberConfirmed { get; init; }
        public bool TwoFactorEnabled { get; init; }
        public DateTimeOffset? LockoutEnd { get; init; }
        public bool LockoutEnabled { get; init; }
        public int AccessFailedCount { get; init; }
        public Guid RoleId { get; init; }
        public string RoleName { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public DateTime LastAccessAt { get; init; }
    }
}
