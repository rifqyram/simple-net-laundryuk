namespace SimpleLaundryuk.Infrastructure.Repositories;

public interface IPersistence
{
    Task<int> SaveChangeAsync();
    void ClearTracking();
    Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);

}