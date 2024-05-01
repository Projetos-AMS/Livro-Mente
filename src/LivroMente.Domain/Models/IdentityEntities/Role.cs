using Microsoft.AspNetCore.Identity;

namespace LivroMente.Domain.Models.IdentityEntities
{
    public class Role : IdentityRole
    {
        public List<UserRole> UserRoles { get; set; }
        public bool IsActive { get; set; }
    }
}