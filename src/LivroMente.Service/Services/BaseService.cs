using LivroMente.Data.Context;
using LivroMente.Domain.Models;
using LivroMente.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivroMente.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly DataContext _context;

        public BaseService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TEntity entity)
        {
            _context.Add(entity);
            await Save();
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<bool> Update(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Update(entity);
            return await Save();
        }
    }
}