namespace Work.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

    Task<T> CreateAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(T item);
}