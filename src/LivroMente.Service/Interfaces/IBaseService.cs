using LivroMente.Domain.Models;


namespace LivroMente.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
       Task<bool> Add(TEntity entity);
       Task<IEnumerable<TEntity>> GetAll();
       Task<bool> Update(string id);
       Task<bool> Delete(string id);
       Task<TEntity> GetById(string id);
       Task<bool> Save();

    }
}