using SimpleLaundryuk.Application.Models.ProductPrice;

namespace SimpleLaundryuk.Application.Models.Product;

public class ProductListResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; }
    public List<ProductPriceResponse> ProductPrice { get; set; } = new();
}