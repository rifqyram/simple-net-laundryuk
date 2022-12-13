using Microsoft.EntityFrameworkCore;

namespace SimpleLaundryuk.Infrastructure.Repositories;

public class DbPersistence : IPersistence
{
    private readonly AppDbContext _context;

    public DbPersistence(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void ClearTracking()
    {
        _context.ChangeTracker.Clear();
    }

    public async Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var transResult = await strategy.ExecuteAsync(async () =>
        {
            await using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await func.Invoke();
                await trans.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        });

        return transResult;
    }
    
}