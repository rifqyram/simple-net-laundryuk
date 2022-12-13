using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimpleLaundryuk.Entity.Entities;

namespace SimpleLaundryuk.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Save(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public TEntity Attach(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> SaveAll(IEnumerable<TEntity> entities)
    {
        var saveAll = entities.ToList();
        await _context.Set<TEntity>().AddRangeAsync(saveAll);
        return saveAll;
    }

    public async Task<TEntity?> FindById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> FindById(Guid id, string[]? includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes == null) return await query.FirstOrDefaultAsync(entity => (entity as EntityBase)!.Id.Equals(id));
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.FirstOrDefaultAsync(entity => (entity as EntityBase)!.Id.Equals(id));
    }

    public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().Where(criteria).FirstOrDefaultAsync();
    }

    public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> criteria, string[]? includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        if (includes == null)
            return await query.Where(criteria).FirstOrDefaultAsync();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(criteria).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (current, include) => current.Include(include));
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, string[]? includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes == null) return await query.Where(criteria).ToListAsync();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(criteria).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int skip, int take)
    {
        return await _context.Set<TEntity>().Where(criteria).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int skip, int take,
        string[]? includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes == null) return await query.Skip(skip).Take(take).ToListAsync();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> criteria, int? skip, int? take,
        Expression<Func<TEntity, object>>? orderBy, string direction)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (orderBy != null)
            query = direction == "ASC" ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

        return await query.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }

    public void DeleteAll(IEnumerable<TEntity> entities)
    {
        _context.RemoveRange(entities);
    }

    public async Task<int> Count()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    public async Task<int> Count(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().CountAsync();
    }
}