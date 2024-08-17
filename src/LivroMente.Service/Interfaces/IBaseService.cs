namespace LivroMente.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
       Task<bool> Add(T entity);
       Task<IEnumerable<T>> GetAll();
       Task<bool> Update(Guid id);
       Task<bool> Delete(Guid id);
       Task<T> GetById(Guid id);
       Task<bool> Save();

    }
}