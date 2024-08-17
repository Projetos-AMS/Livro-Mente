using Microsoft.AspNetCore.Identity;

namespace LivroMente.Domain.Models.IdentityEntities
{
    public class User : IdentityUser
    {
        public string CompleteName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public bool IsActive { get; set; }
    }
}