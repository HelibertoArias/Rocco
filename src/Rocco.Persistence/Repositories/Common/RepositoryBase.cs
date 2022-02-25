// <copyright file="RepositoryBase.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rocco.Application.Contracts.Persistence.Common;
using Rocco.Domain.Base;

namespace Rocco.Persistence.Repositories.Common;
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
{
    protected readonly RoccoContext _dbContext;

    public RepositoryBase(RoccoContext repositoryContext)
    {
        _dbContext = repositoryContext;
    }
    public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
    {
        return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ?
                _dbContext.Set<T>()
                    .AsNoTracking() :
                _dbContext.Set<T>();
    }

    public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges ?
                _dbContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking() :
                _dbContext.Set<T>().Where(expression);
    }

    public async Task<T?> FindOneByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {

        return !trackChanges ?
             await _dbContext.Set<T>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(expression)
                        .ConfigureAwait(true) :
              await _dbContext.Set<T>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(expression)
                        .ConfigureAwait(true);

    }

    public async Task Add(T entity) => await _dbContext.Set<T>().AddAsync(entity).ConfigureAwait(true);

    public void Update(T entity) => _dbContext.Set<T>().Update(entity);

    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync().ConfigureAwait(true);
    }

}
