using System.Linq.Expressions;

namespace SimpleLaundryuk.Infrastructure.Repositories;

public interface IRepository<TEntity>
{
    Task<TEntity> Save(TEntity entity);
    TEntity Attach(TEntity entity); 
    Task<IEnumerable<TEntity>> SaveAll(IEnumerable<TEntity> entities);
    Task<TEntity?> FindById(Guid id);
    Task<TEntity?> FindById(Guid id, string[]? includes);
    Task<TEntity?> Find(Expression<Func<TEntity, bool>> criteria);
    Task<TEntity?> Find(Expression<Func<TEntity, bool>> criteria, string[]? includes);
    Task<IEnumerable<TEntity>> FindAll();
    Task<IEnumerable<TEntity>> FindAll(string[] includes);
    Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria);
    Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, string[]? includes);
    Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int skip, int take);
    Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int skip, int take, string[]? includes);
    Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int? skip, int? take, Expression<Func<TEntity, object>>? orderBy, string direction);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteAll(IEnumerable<TEntity> entities);
    Task<int> Count();
    Task<int> Count(Expression<Func<TEntity, bool>> criteria);
}