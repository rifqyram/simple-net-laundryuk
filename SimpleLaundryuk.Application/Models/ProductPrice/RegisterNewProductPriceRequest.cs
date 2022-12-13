using SimpleLaundryuk.Application.Models.Product;

namespace SimpleLaundryuk.Application.Models.ProductPrice;

public class RegisterNewProductPriceRequest
{
    public int Price { get; set; }
    public bool IsActive { get; set; }
    public RegisterNewProductRequest Product { get; set; } = new();
}