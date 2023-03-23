namespace eShop.Core.Interfaces;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<T> CreateAsync(T obj, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T obj, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}