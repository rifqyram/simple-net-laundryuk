using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Entity.Entities;
using SimpleLaundryuk.Infrastructure.Repositories;

namespace SimpleLaundryuk.Application.Services.ProductPriceServices;

public class ProductPriceService : IProductPriceService
{
    private readonly IRepository<ProductPrice> _repository;

    public ProductPriceService(IRepository<ProductPrice> repository)
    {
        _repository = repository;
    }

    public async Task<ProductPriceResponse> GetById(string id)
    {
        var productPrice = await FindByIdOrThrowNotFound(id);
        return new ProductPriceResponse
        {
            Id = productPrice.Id.ToString(),
            Price = productPrice.Price,
            IsActive = productPrice.IsActive,
            Product = new ProductResponse
            {
                Id = productPrice.Product.Id.ToString(),
                Name = productPrice.Product.Name,
                Duration = productPrice.Product.Duration
            }
        };
    }

    public async Task<List<ProductPriceResponse>> GetAll()
    {
        var productPrices = await _repository.FindAll(new[] { "Product.ProductPrices" });
        return productPrices.Select(productPrice => new ProductPriceResponse
        {
            Id = productPrice.Id.ToString(),
            Price = productPrice.Price,
            IsActive = productPrice.IsActive,
            Product = new ProductResponse
            {
                Id = productPrice.Product.Id.ToString(),
                Name = productPrice.Product.Name,
                Duration = productPrice.Product.Duration
            }
        }).ToList();
    }

    public async Task<ProductPriceResponse> GetByProductId(string id)
    {
        try
        {
            var productPrice =
                await _repository.Find(price => price.Product.Id.Equals(Guid.Parse(id)),
                    new[] { "Product.ProductPrices" });

            if (productPrice is null) throw new Exception("product price not found");

            return new ProductPriceResponse
            {
                Id = productPrice.Id.ToString(),
                Price = productPrice.Price,
                IsActive = productPrice.IsActive,
                Product = new ProductResponse
                {
                    Id = productPrice.Product.Id.ToString(),
                    Name = productPrice.Product.Name,
                    Duration = productPrice.Product.Duration
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<ProductPrice> FindByIdOrThrowNotFound(string id)
    {
        try
        {
            var productPrice = await _repository.FindById(Guid.Parse(id), new[] { "Product" });
            if (productPrice is null) throw new Exception("product price not found");
            return productPrice;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}