using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class User: IdentityUser<Guid>
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastAccessAt { get; set; }

        [NotMapped]
        public Guid RoleId { get; set; }

        [NotMapped]
        public string RoleName { get; set; } = string.Empty;

    }
}
