using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Application.Services.ProductPriceServices;
using SimpleLaundryuk.Entity.Entities;
using SimpleLaundryuk.Infrastructure.Repositories;

namespace SimpleLaundryuk.Application.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public async Task<ProductResponse> Create(RegisterNewProductRequest request)
    {
        var productResponse = await _persistence.ExecuteTransactionAsync(async () =>
        {
            var productPrices = new List<ProductPrice>
            {
                new()
                {
                    Price = request.Price,
                    IsActive = true,
                }
            };

            var productReq = new Product
            {
                Name = request.Name,
                Duration = request.Duration,
                ProductPrices = productPrices
            };

            var product = await _repository.Save(productReq);
            var productPrice = product.ProductPrices!.FirstOrDefault()!;

            await _persistence.SaveChangeAsync();
            return new ProductResponse
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Duration = product.Duration,
                ProductPrice = new ProductPriceResponse()
                {
                    Id = productPrice.Id.ToString(),
                    Price = productPrice.Price,
                    IsActive = productPrice.IsActive,
                    Product = new ProductResponse
                    {
                        Id = productPrice.Product.Id.ToString(),
                        Name = productPrice.Product.Name,
                        Duration = productPrice.Product.Duration,
                    }
                }
            };
        });

        return productResponse;
    }

    public async Task<ProductResponse> GetById(string id)
    {
        var product = await FindProductByIdOrThrowNotFound(id);

        var productResponse = new ProductResponse
        {
            Id = product.Id.ToString(),
            Name = product.Name,
            Duration = product.Duration,
        };

        if (product.ProductPrices == null)
            return productResponse;

        var productPrice = product.ProductPrices.FirstOrDefault(price => price.IsActive);

        if (productPrice != null)
            productResponse.ProductPrice = new ProductPriceResponse
            {
                Id = productPrice.Id.ToString(),
                Price = productPrice.Price,
                IsActive = productPrice.IsActive,
                Product = new ProductResponse
                {
                    Id = productPrice.Product.Id.ToString(),
                    Name = productPrice.Product.Name,
                    Duration = productPrice.Product.Duration,
                }
            };

        return productResponse;
    }

    public async Task<List<ProductListResponse>> GetAll()
    {
        var productResponse = new List<ProductListResponse>();

        var products = await _repository
            .FindAll(
                product => product.ProductPrices != null && product.ProductPrices.Any(price => price.IsActive == true),
                new[] { "ProductPrices" });

        foreach (var product in products)
        {
            var productPriceResponses = new List<ProductPriceResponse>();
            if (product.ProductPrices != null)
                productPriceResponses.AddRange(product.ProductPrices.Select(productPrice => new ProductPriceResponse
                {
                    Id = productPrice.Id.ToString(),
                    Price = productPrice.Price,
                    IsActive = productPrice.IsActive,
                    Product = new ProductResponse
                    {
                        Id = productPrice.Product.Id.ToString(),
                        Name = productPrice.Product.Name,
                        Duration = productPrice.Product.Duration,
                    },
                }));

            var productListResponse = new ProductListResponse()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Duration = product.Duration,
                ProductPrice = productPriceResponses
            };
            productResponse.Add(productListResponse);
        }

        return productResponse;
    }

    public async Task<ProductResponse> Update(UpdateProductRequest request)
    {
        var currentProduct = await FindProductByIdOrThrowNotFound(request.Id);

        if (request.ProductPrice is null)
        {
            return await _persistence.ExecuteTransactionAsync(async () =>
            {
                currentProduct.Name = request.Name;
                currentProduct.Duration = request.Duration;
                _repository.Update(currentProduct);
                await _persistence.SaveChangeAsync();

                var productResponse = new ProductResponse
                {
                    Id = currentProduct.Id.ToString(),
                    Name = currentProduct.Name,
                    Duration = currentProduct.Duration,
                };

                if (currentProduct.ProductPrices == null) return productResponse;
                var productPrice = currentProduct.ProductPrices.FirstOrDefault();

                if (productPrice == null) return productResponse;

                productResponse.ProductPrice = new ProductPriceResponse
                {
                    Id = productPrice.Id.ToString(),
                    Price = productPrice.Price,
                    IsActive = productPrice.IsActive,
                    Product = new ProductResponse
                    {
                        Id = productPrice.Product.Id.ToString(),
                        Name = productPrice.Product.Name,
                        Duration = productPrice.Product.Duration,
                    }
                };

                return productResponse;
            });
        }

        return await _persistence.ExecuteTransactionAsync(async () =>
        {
            currentProduct.Name = request.Name;
            currentProduct.Duration = request.Duration;

            var productResponse = new ProductResponse
            {
                Id = currentProduct.Id.ToString(),
                Name = currentProduct.Name,
                Duration = currentProduct.Duration,
            };

            var productPrice = new ProductPrice
            {
                Price = request.ProductPrice.Price,
                IsActive = true,
                Product = currentProduct
            };

            foreach (var currentProductPrice in currentProduct.ProductPrices!)
            {
                if (currentProductPrice.IsActive)
                {
                    currentProductPrice.IsActive = false;
                }
            }

            currentProduct.ProductPrices.Add(productPrice);

            productResponse.ProductPrice = new ProductPriceResponse
            {
                Price = productPrice.Price,
                IsActive = productPrice.IsActive,
                Product = new ProductResponse
                {
                    Id = productPrice.Product.Id.ToString(),
                    Name = productPrice.Product.Name,
                    Duration = productPrice.Product.Duration,
                }
            };

            _repository.Update(currentProduct);
            await _persistence.SaveChangeAsync();

            return productResponse;
        });
    }

    public async Task DeleteById(string id)
    {
        var currentProduct = await FindProductByIdOrThrowNotFound(id);
        _repository.Delete(currentProduct);
        await _persistence.SaveChangeAsync();
    }

    private async Task<Product> FindProductByIdOrThrowNotFound(string id)
    {
        try
        {
            var product = await _repository.FindById(Guid.Parse(id), new[] { "ProductPrices" });
            if (product == null) throw new Exception("product not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}