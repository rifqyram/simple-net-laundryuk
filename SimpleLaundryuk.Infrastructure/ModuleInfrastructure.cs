using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleLaundryuk.Infrastructure.Repositories;

namespace SimpleLaundryuk.Infrastructure;

public static class ModuleInfrastructure
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Connection")))
            .AddTransient<IPersistence, DbPersistence>()
            .AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}