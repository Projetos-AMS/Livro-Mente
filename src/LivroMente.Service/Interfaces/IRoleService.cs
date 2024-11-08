using LivroMente.Domain.Models.IdentityEntities;

namespace LivroMente.Service.Interfaces
{
    public interface IRoleService
    {
        Task<bool> Add(Role entity);
       Task<IEnumerable<Role>> GetAll();
       Task<bool> Update(Guid id);
       Task<bool> Save();
    }
}