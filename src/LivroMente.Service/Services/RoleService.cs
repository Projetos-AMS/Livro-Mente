using LivroMente.Data.Context;
using LivroMente.Domain.Models.IdentityEntities;

namespace LivroMente.Service.Services
{
    public class RoleService : BaseService<Role>
    {
        public RoleService(DataContext context): base(context){}  
    }
}