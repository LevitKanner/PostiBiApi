using System.Linq.Expressions;
using Api.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly ApplicationContext _context;

    public RepositoryBase(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChange)
    {
        return trackChange ? _context.Set<T>().Where(condition) : _context.Set<T>().Where(condition).AsNoTracking();
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}