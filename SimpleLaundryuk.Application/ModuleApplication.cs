using Microsoft.Extensions.DependencyInjection;
using SimpleLaundryuk.Application.Services.BillServices;
using SimpleLaundryuk.Application.Services.CustomerServices;
using SimpleLaundryuk.Application.Services.ProductPriceServices;
using SimpleLaundryuk.Application.Services.ProductServices;

namespace SimpleLaundryuk.Application;

public static class ModuleApplication
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>()
            .AddTransient<IProductService, ProductService>()
            .AddTransient<IProductPriceService, ProductPriceService>()
            .AddTransient<IBillService, BillService>();
    }
}