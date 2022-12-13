using SimpleLaundryuk.Application.Models.ProductPrice;

namespace SimpleLaundryuk.Application.Models.BillDetail;

public class BillDetailResponse
{
    public string Id { get; set; } = string.Empty;
    public int Weight { get; set; }
    public ProductPriceResponse ProductPrice { get; set; }
}