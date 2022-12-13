namespace SimpleLaundryuk.Application.Models.ProductPrice;

public class UpdateProductPriceRequest
{
    public string Id { get; set; } = string.Empty;
    public int Price { get; set; }
    public bool IsActive { get; set; }
    public string ProductId { get; set; } = string.Empty;
}