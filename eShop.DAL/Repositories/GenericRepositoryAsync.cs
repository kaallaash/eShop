﻿using eShop.Core.Interfaces;
using eShop.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Repositories;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepositoryAsync(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> CreateAsync(T obj, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(obj, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return obj;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        if (entity is not null)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<T> UpdateAsync(T obj, CancellationToken cancellationToken)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return obj;
    }
}
