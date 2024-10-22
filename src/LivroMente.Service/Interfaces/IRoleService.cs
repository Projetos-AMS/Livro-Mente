using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Models.IdentityEntities;

namespace LivroMente.Service.Interfaces
{
    public interface IRoleService <TRole> where TRole : Role
    {
        Task<bool> Add(TRole entity);
       Task<IEnumerable<TRole>> GetAll();
       Task<bool> Update(Guid id);
       Task<bool> Save();
    }
}