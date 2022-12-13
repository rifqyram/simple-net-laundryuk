using SimpleLaundryuk.Application.Models.ProductPrice;

namespace SimpleLaundryuk.Application.Models.Product;

public class UpdateProductRequest
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; }
    public UpdateProductPriceRequest? ProductPrice { get; set; }
}