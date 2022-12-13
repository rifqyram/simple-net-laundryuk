namespace SimpleLaundryuk.Application.Models.Product;

public class RegisterNewProductRequest
{
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; }
    public int Price { get; set; }
}