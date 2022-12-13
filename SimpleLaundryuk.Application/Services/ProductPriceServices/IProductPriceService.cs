using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Entity.Entities;

namespace SimpleLaundryuk.Application.Services.ProductPriceServices;

public interface IProductPriceService
{
    Task<ProductPriceResponse> GetById(string id);
    Task<List<ProductPriceResponse>> GetAll();

    Task<ProductPriceResponse> GetByProductId(string id);
}
    