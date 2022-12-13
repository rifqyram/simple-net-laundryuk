using SimpleLaundryuk.Application.Models.Product;

namespace SimpleLaundryuk.Application.Models.ProductPrice;

public class ProductPriceResponse
{
    public string Id { get; set; } = string.Empty;
    public int Price { get; set; }
    public bool IsActive { get; set; }

    public ProductResponse Product { get; set; }
}