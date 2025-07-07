using System.Security.Claims;
using TechZone.Ecommerce.Interfaces.Services;

namespace TechZone.Ecommerce.WebApi.Services
{
    internal sealed class CurrentUser(IHttpContextAccessor _httpContextAccessor) : ICurrentUser
    {
        public Guid? UserId => GetUserIdFromClaims();
        public string? UserName => GetUserNameFromClaims();
        public string? Email => GetUserEmailFromClaims();
        public string? Role => GetRoleFromClaims();
        public bool IsAuthenticated => GetIsAuthenticatedFromClaims();

        private bool GetIsAuthenticatedFromClaims()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
        private string? GetRoleFromClaims()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        }
        private string? GetUserEmailFromClaims()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        private string? GetUserNameFromClaims()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        }
        private Guid? GetUserIdFromClaims()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaim, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}
