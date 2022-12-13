using SimpleLaundryuk.Application.Models.Product;

namespace SimpleLaundryuk.Application.Services.ProductServices;

public interface IProductService
{
    Task<ProductResponse> Create(RegisterNewProductRequest request);
    Task<ProductResponse> GetById(string id);
    Task<List<ProductListResponse>> GetAll();
    Task<ProductResponse> Update(UpdateProductRequest request);
    Task DeleteById(string id);
}