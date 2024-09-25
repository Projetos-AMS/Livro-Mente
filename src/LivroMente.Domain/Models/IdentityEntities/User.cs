using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace LivroMente.Domain.Models.IdentityEntities
{
    public class User : IdentityUser
    {
        public string CompleteName { get; set; }
        public bool IsActive { get; set; }
        
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }
    }
}