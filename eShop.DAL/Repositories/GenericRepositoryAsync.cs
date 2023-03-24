using eShop.Core.Entities;
using eShop.Core.Interfaces;
using eShop.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Repositories;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepositoryAsync(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<T> CreateAsync(T obj, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(obj, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return obj;
    }

    public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        var entityIsNull = entity is null;

        if (entityIsNull)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return entityIsNull;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public virtual async Task<T> UpdateAsync(T obj, CancellationToken cancellationToken)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return obj;
    }
}
