using LivroMente.Data.Context;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivroMente.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        public RoleService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Role entity)
        {
            _context.Add(entity);
            await Save();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Set<Role>().ToListAsync();
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(Guid id)
        {
            var entity = await _context.Set<Role>().FindAsync(id);
            _context.Set<Role>().Update(entity);
            return await Save();
        }
    }
}