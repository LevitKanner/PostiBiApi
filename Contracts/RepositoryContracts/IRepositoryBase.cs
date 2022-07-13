using System.Linq.Expressions;

namespace Api.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChange);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}